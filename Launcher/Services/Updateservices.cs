using System.Net.Http.Json;

public class UpdateService
{
    private const string REPO = "ngshp/Launcher1";
    public async Task CheckUpdate()
    {
        using var http = new HttpClient();
        http.DefaultRequestHeaders.UserAgent.ParseAdd("PBNG-Launcher");
        
        var latest = await http.GetFromJsonAsync<GitHubRelease>(
            $"https://api.github.com/repos/{REPO}/releases/latest");
        
        var current = "1.0.36"; // Assembly.GetExecutingAssembly().GetName().Version
        var latestVer = latest.tag_name.TrimStart('v');
        
        if (latestVer != current)
        {
            // Download PBNG-Setup-{latestVer}.exe dan jalanin silent update
            var url = latest.assets.First(a => a.name.EndsWith(".exe")).browser_download_url;
            // MessageBox.Show($"Update {latestVer} tersedia!");
            // Process.Start(new ProcessStartInfo { FileName = installerPath, Arguments = "/SILENT" });
        }
    }
    record GitHubRelease(string tag_name, Asset[] assets);
    record Asset(string name, string browser_download_url);
}
