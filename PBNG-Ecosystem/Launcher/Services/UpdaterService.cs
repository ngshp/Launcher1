using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PBNG.Launcher.Services
{
    public class UpdaterService
    {
        private readonly HttpClient _http = new HttpClient();
        private const string RepoOwner = "ngshp";
        private const string RepoName = "Launcher1";

        public UpdaterService()
        {
            _http.DefaultRequestHeaders.Add("User-Agent", "PBNG-Launcher-Updater");
        }

        public async Task<(bool hasUpdate, string latestVer, string downloadUrl)> CheckAsync()
        {
            try
            {
                var url = $"https://api.github.com/repos/{RepoOwner}/{RepoName}/releases/latest";
                var json = await _http.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var latestTag = root.GetProperty("tag_name").GetString() ?? "v0.0.0";
                var latestVer = latestTag.TrimStart('v');

                // Versi current dari assembly
                var currentVer = typeof(UpdaterService).Assembly.GetName().Version?.ToString() ?? "0.0.0";
                
                // Cari asset .exe installer
                string downloadUrl = "";
                if (root.TryGetProperty("assets", out var assets))
                {
                    foreach (var asset in assets.EnumerateArray())
                    {
                        var name = asset.GetProperty("name").GetString() ?? "";
                        if (name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                        {
                            downloadUrl = asset.GetProperty("browser_download_url").GetString() ?? "";
                            break;
                        }
                    }
                }

                // Bandingkan versi simple
                var hasUpdate = !currentVer.StartsWith(latestVer) && latestVer != "0.0.0" && !string.IsNullOrEmpty(downloadUrl);
                
                // Untuk dev, selalu anggap ada update jika ada downloadUrl biar bisa test
                if (!string.IsNullOrEmpty(downloadUrl) && latestVer != currentVer)
                    hasUpdate = true;

                return (hasUpdate, latestVer, downloadUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update check failed: {ex.Message}");
                return (false, "", "");
            }
        }

        public async Task DownloadAndInstallAsync(string downloadUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(downloadUrl)) return;

                var tempPath = Path.Combine(Path.GetTempPath(), "PBNG-Launcher-Setup.exe");
                var data = await _http.GetByteArrayAsync(downloadUrl);
                await File.WriteAllBytesAsync(tempPath, data);

                // Jalankan installer dan tutup launcher
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });

                System.Windows.Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Download failed: {ex.Message}");
                System.Windows.MessageBox.Show($"Gagal download update: {ex.Message}", "Update Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
