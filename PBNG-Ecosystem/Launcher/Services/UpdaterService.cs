using System; using System.IO; using System.Net.Http; using System.Text.Json; using System.Threading.Tasks; using System.Diagnostics;

namespace PBNG.Launcher.Services
{
    public class AutoUpdater
    {
        private readonly HttpClient http = new HttpClient();
        public string VersionUrl = "https://cdn.pbng.id/launcher-v360/version.json";
        public string CurrentVersion = "3.6.0";
        
        public async Task<UpdateInfo> CheckAsync(Action<string> log)
        {
            log?.Invoke("Checking auto update...");
            try {
                var json = await http.GetStringAsync(VersionUrl);
                var info = JsonSerializer.Deserialize<UpdateInfo>(json);
                log?.Invoke($"Server: v{info.version} | Local: v{CurrentVersion} | MT:{info.maintenance}");
                return info;
            } catch(Exception ex) { log?.Invoke($"Check failed: {ex.Message}"); return null; }
        }

        public async Task DoUpdateAsync(UpdateInfo info, Action<string,int> progress)
        {
            if(info == null) return;
            // 1. Auto update launcher.exe
            if(info.version != CurrentVersion && !string.IsNullOrEmpty(info.launcher_exe_url))
            {
                progress?.Invoke("Downloading launcher.exe update...", 10);
                await DownloadAsync(info.launcher_exe_url, "PBNG.Launcher.v360.new.exe");
                File.WriteAllText("update_launcher.pending", info.version);
            }
            // 2. Auto update tampilan / skin / UI / ico / PNG
            if(info.force_skin_update || info.skin_zip_url != null)
            {
                progress?.Invoke("Updating tampilan & skin/UI...", 30);
                if(!string.IsNullOrEmpty(info.hero_url)) await DownloadAsync(info.hero_url, "hero.png.new");
                if(!string.IsNullOrEmpty(info.skin_zip_url)) await DownloadAsync(info.skin_zip_url, "skin.zip");
                if(!string.IsNullOrEmpty(info.icons_zip_url)) await DownloadAsync(info.icons_zip_url, "icons.zip");
            }
            // 3. Auto update file client game
            if(info.client_files != null)
            {
                foreach(var file in info.client_files)
                {
                    progress?.Invoke($"Updating game file {file.name}...", 60);
                    await DownloadAsync(file.url, $"Game/{file.path}.new");
                }
            }
            // 4. Auto update MT
            if(info.maintenance) File.WriteAllText("maintenance.flag", info.maintenance_message);
            else if(File.Exists("maintenance.flag")) File.Delete("maintenance.flag");

            progress?.Invoke("Update ready! Restarting...", 100);
            await Task.Delay(1000);
            Process.Start("PBNG.Launcher.v360.exe", "--apply-update");
            Environment.Exit(0);
        }

        private async Task DownloadAsync(string url, string dest)
        {
            var bytes = await http.GetByteArrayAsync(url);
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(dest)) ?? ".");
            await File.WriteAllBytesAsync(dest, bytes);
        }

        public class UpdateInfo
        {
            public string version {get;set;}
            public string launcher_exe_url {get;set;}
            public string hero_url {get;set;}
            public string skin_zip_url {get;set;}
            public string icons_zip_url {get;set;}
            public bool force_skin_update {get;set;}
            public bool maintenance {get;set;}
            public string maintenance_message {get;set;}
            public GameFile[] client_files {get;set;}
            public string changelog {get;set;}
        }
        public class GameFile { public string name {get;set;} public string path {get;set;} public string url {get;set;} public string hash {get;set;} }
    }
}
