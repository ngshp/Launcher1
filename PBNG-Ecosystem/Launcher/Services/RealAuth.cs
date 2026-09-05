using System; using System.Net.Http; using System.Text; using System.Text.Json; using System.Threading.Tasks; using System.Timers;

namespace PBNG.Launcher.Services
{
    public class RealAuth
    {
        private readonly HttpClient http = new HttpClient();
        public string ApiBase = "https://api.pbng.id/launcher-v360/auth";
        public string Token; public UserData User;
        private Timer liveCheckTimer;

        public async Task<LoginResult> LoginNyataAsync(string user, string pass)
        {
            var body = new { username=user, password=pass, hwid=GetHWID(), launcher_version="3.6.0" };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var res = await http.PostAsync($"{ApiBase}/login", content);
            var json = await res.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResult>(json);
            if(result.success){ Token=result.token; User=result.user; http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token); StartLiveCheck(); }
            return result;
        }

        public async Task<LoginResult> RegisterNyataAsync(string user, string email, string pass)
        {
            var body = new { username=user, email, password=pass, hwid=GetHWID() };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var res = await http.PostAsync($"{ApiBase}/register", content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginResult>(json);
        }

        public void StartLiveCheck()
        {
            liveCheckTimer = new Timer(30000); // live check session tiap 30 detik
            liveCheckTimer.Elapsed += async (s,e) => await LiveCheckAsync();
            liveCheckTimer.Start();
        }

        public async Task<bool> LiveCheckAsync()
        {
            if(string.IsNullOrEmpty(Token)) return false;
            try{ var res = await http.GetAsync($"{ApiBase}/live-check"); return res.IsSuccessStatusCode; }
            catch{ return false; }
        }

        public async Task<bool> LiveCheckUpdateAsync()
        {
            try{ var res = await http.GetAsync($"{ApiBase}/check-update"); var json = await res.Content.ReadAsStringAsync(); var data = JsonSerializer.Deserialize<UpdateCheck>(json); return data.has_update; }
            catch{ return false; }
        }

        private string GetHWID() => Environment.MachineName + "-" + Environment.UserName + "-" + Environment.OSVersion.VersionString;
        public class LoginResult{ public bool success {get;set;} public string message {get;set;} public string token {get;set;} public UserData user {get;set;} }
        public class UserData{ public string username {get;set;} public string email {get;set;} public int level {get;set;} public string rank {get;set;} public int coin {get;set;} }
        public class UpdateCheck{ public bool has_update {get;set;} public string latest_version {get;set;} }
    }
}
