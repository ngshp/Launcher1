using System; using System.Net.Http; using System.Text.Json; using System.Threading.Tasks; using System.Timers;

namespace PBNG.Launcher.Services
{
    public class LiveServerStatus
    {
        private readonly HttpClient http = new HttpClient();
        public string StatusUrl = "https://api.pbng.id/launcher-v360/status";
        private Timer timer;
        public event Action<StatusData> OnLiveUpdate;
        public StatusData LastStatus;

        public void Start()
        {
            timer = new Timer(3000); // live update tiap 3 detik
            timer.Elapsed += async (s,e) => await FetchAsync();
            timer.Start();
            _ = FetchAsync();
        }
        public void Stop() => timer?.Stop();

        public async Task<StatusData> FetchAsync()
        {
            try {
                var json = await http.GetStringAsync(StatusUrl);
                LastStatus = JsonSerializer.Deserialize<StatusData>(json);
                OnLiveUpdate?.Invoke(LastStatus);
                return LastStatus;
            } catch {
                LastStatus = new StatusData{ status="OFFLINE", online=0, maintenance=true, message="Offline" };
                OnLiveUpdate?.Invoke(LastStatus);
                return LastStatus;
            }
        }

        public class StatusData
        {
            public string status {get;set;} // NORMAL, MAINTENANCE, FULL, UPDATE, OFFLINE
            public int online {get;set;}
            public int max {get;set;}=3000;
            public bool maintenance {get;set;}
            public string message {get;set;}
            public string server_version {get;set;}
            public bool login_enabled {get;set;}=true;
            public bool register_enabled {get;set;}=true;
            public DateTime last_check {get;set;}=DateTime.Now;
        }
    }
}
