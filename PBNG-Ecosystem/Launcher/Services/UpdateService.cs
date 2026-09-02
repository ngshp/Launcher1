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
    public class UpdateService
    {
        private const string Repo = "ngshp/Launcher1";
        private static readonly HttpClient http = new HttpClient();

        static UpdateService()
        {
            http.DefaultRequestHeaders.UserAgent.ParseAdd("PBNG-Launcher/1.0");
            http.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github.v3+json");
        }

        public record GitHubAsset(string name, string browser_download_url);
        public record GitHubRelease(string tag_name, GitHubAsset[] assets);

        public async Task<(bool hasUpdate, string latestVersion, string downloadUrl)> CheckAsync()
        {
            try
            {
                var release = await http.GetFromJsonAsync<GitHubRelease>($"https://api.github.com/repos/{Repo}/releases/latest");
                if (release == null) return (false, "", "");

                var latest = release.tag_name.TrimStart('v');
                var current = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.36";
                // Normalize: compare as Version
                if (Version.TryParse(latest, out var vLatest) && Version.TryParse(current, out var vCurrent))
                {
                    if (vLatest <= vCurrent) return (false, latest, "");
                }
                else if (latest == current) return (false, latest, "");

                var asset = release.assets.FirstOrDefault(a => a.name.StartsWith("PBNG-Setup") && a.name.EndsWith(".exe"));
                return (true, latest, asset?.browser_download_url ?? "");
            }
            catch
            {
                return (false, "", "");
            }
        }

        public async Task DownloadAndInstallAsync(string url)
        {
            var temp = Path.Combine(Path.GetTempPath(), $"PBNG-Setup-{Guid.NewGuid():N}.exe");
            var data = await http.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(temp, data);
            Process.Start(new ProcessStartInfo { FileName = temp, Arguments = "/SILENT /CLOSEAPPLICATIONS", UseShellExecute = true });
            Environment.Exit(0);
        }
    }
}
