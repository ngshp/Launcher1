using DiscordRPC;
using DiscordRPC.Logging;

namespace PBNG.Launcher.Services
{
    public sealed class DiscordService : IDisposable
    {
        private DiscordRpcClient? _client;
        private bool _inited;
        private const string ClientId = "1418576866623442955";

        public void Init(string clientId = ClientId)
        {
            if (_inited) return;
            try
            {
                _client = new DiscordRpcClient(clientId);
                _client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
                _client.OnReady += (s, e) => 
                {
                    Console.WriteLine($"[Discord] Ready: {e.User.Username}");
                    SetPresence("Di PBNG Launcher", "Siap Main Point Blank", "pbng_icon");
                };
                _client.Initialize();
                _inited = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Discord] Init Fail: {ex.Message}");
            }
        }

        public void SetPresence(string details, string state, string largeImageKey = "pbng_icon", string smallImageKey = "verified")
        {
            if (_client == null || !_client.IsInitialized) return;
            try
            {
                _client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = state,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = "PBNG Launcher v1.0.104 - SUCCESS",
                        SmallImageKey = smallImageKey,
                        SmallImageText = "Verified • Build #105"
                    },
                    Buttons = new DiscordRPC.Button[]
                    {
                        new DiscordRPC.Button() { Label = "Download Launcher", Url = "https://github.com/ngshp/Launcher1/releases" },
                        new DiscordRPC.Button() { Label = "Website", Url = "https://ngshp.github.io/Launcher1/" }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Discord] SetPresence Fail: {ex.Message}");
            }
        }

        public void SetInGame(string serverName = "PBNG Official")
        {
            SetPresence($"Main di {serverName}", "Point Blank NG • In-Game", "pbng_icon", "ingame");
        }

        public void SetIdle()
        {
            SetPresence("Di PBNG Launcher", "Idle • Siap Main", "pbng_icon", "idle");
        }

        public void Dispose()
        {
            try
            {
                _client?.ClearPresence();
                _client?.Deinitialize();
                _client?.Dispose();
                _client = null;
                _inited = false;
            }
            catch { }
        }
    }
}
