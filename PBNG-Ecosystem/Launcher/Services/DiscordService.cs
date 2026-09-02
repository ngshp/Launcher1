using System;
using DiscordRPC;

namespace PBNG.Launcher.Services
{
    public class DiscordService : IDisposable
    {
        private DiscordRpcClient? _client;
        public void Init()
        {
            try
            {
                _client = new DiscordRpcClient("1370000000000000000");
                _client.Initialize();
                SetPresence("Di PBNG Launcher", "v1.0.37");
            }
            catch { }
        }
        public void SetPresence(string details, string state)
        {
            if (_client == null) return;
            try
            {
                _client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = state,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = "pbng_icon",
                        LargeImageText = "PBNG Launcher"
                    }
                });
            }
            catch { }
        }
        public void Dispose()
        {
            try { _client?.Dispose(); } catch { }
        }
    }
}
