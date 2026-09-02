using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace PBNG.Launcher.Services
{
    public class UpdaterService
    {
        private const string Repo = "ngshp/Launcher1";
        private static readonly HttpClient http = new HttpClient();

        static UpdaterService()
        {
            http.DefaultRequestHeaders.UserAgent.ParseAdd("PBNG-Launcher/1.0.104");
            http.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github.v3+json");
            http.Timeout = TimeSpan.FromSeconds(15);
        }

        public record GitHubAsset(string name, string browser_download_url, long size);
        public record GitHubRelease(string tag_name, string name, GitHubAsset[] assets, string body);

        public async Task<(bool hasUpdate, string latestVersion, string downloadUrl, long size)> CheckAsync()
        {
            try
            {
                var release = await http.GetFromJsonAsync<GitHubRelease>($"https://api.github.com/repos/{Repo}/releases/latest");
                if (release == null) return (false, "", "", 0);

                var latest = release.tag_name.TrimStart('v');
                var current = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.104";

                if (Version.TryParse(latest, out var vLatest) && Version.TryParse(current, out var vCurrent))
                {
                    if (vLatest <= vCurrent) return (false, latest, "", 0);
                }
                else if (latest == current) return (false, latest, "", 0);

                var asset = release.assets.FirstOrDefault(a => a.name.Contains("Setup") && a.name.EndsWith(".exe"))
                         ?? release.assets.FirstOrDefault(a => a.name.EndsWith(".exe"))
                         ?? release.assets.FirstOrDefault(a => a.name.EndsWith(".zip"));

                return (true, latest, asset?.browser_download_url ?? "", asset?.size ?? 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Update check fail: {ex.Message}");
                return (false, "", "", 0);
            }
        }

        public async Task DownloadAndInstallAsync(string url, Action<int>? progressCallback = null)
        {
            try
            {
                var temp = Path.Combine(Path.GetTempPath(), $"PBNG-Setup-v{Guid.NewGuid():N}.exe");
                
                using var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                
                var total = response.Content.Headers.ContentLength ?? -1L;
                var canReport = total != -1 && progressCallback != null;
                
                using var contentStream = await response.Content.ReadAsStreamAsync();
                using var fileStream = new FileStream(temp, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
                
                var buffer = new byte[8192];
                long totalRead = 0;
                int read;
                
                while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    await fileStream.WriteAsync(buffer, 0, read);
                    totalRead += read;
                    if (canReport)
                    {
                        var pct = (int)((totalRead * 100) / total);
                        progressCallback?.Invoke(pct);
                    }
                }

                Process.Start(new ProcessStartInfo 
                { 
                    FileName = temp, 
                    Arguments = "/SILENT /CLOSEAPPLICATIONS /RESTARTAPPLICATIONS", 
                    UseShellExecute = true,
                    Verb = "runas"
                });
                
                System.Windows.Application.Current?.Shutdown();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Update gagal: {ex.Message}\n\nDownload manual di https://github.com/ngshp/Launcher1/releases", "PBNG Launcher - Update Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                Process.Start(new ProcessStartInfo { FileName = "https://github.com/ngshp/Launcher1/releases", UseShellExecute = true });
            }
        }

        public void OpenReleasesPage()
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/ngshp/Launcher1/releases", UseShellExecute = true });
        }
    }

    public class UpdateService : UpdaterService { }
}
