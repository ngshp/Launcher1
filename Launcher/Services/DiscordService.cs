using System;
using DiscordRPC;

namespace PBNG.Launcher.Services
{
    public class DiscordService : IDisposable
    {
        private DiscordRpcClient client;

        public void Init(string clientId = "1234567890123456789") // GANTI INI nanti dengan Discord App ID Toko
        {
            client = new DiscordRpcClient(clientId);
            client.OnReady += (s, e) => Console.WriteLine("Discord RPC Ready");
            client.Initialize();
            SetPresence("In Launcher", "Browsing Ecosystem");
        }

        public void SetPresence(string details, string state, string largeImage = "pbng_icon")
        {
            if (client == null) return;
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Timestamps = new Timestamps() { Start = DateTime.UtcNow },
                Assets = new Assets() 
                { 
                    LargeImageKey = largeImage, 
                    LargeImageText = "PBNG Launcher v1.0.36" 
                },
                Buttons = new Button[] 
                { 
                    new Button() 
                    { 
                        Label = "Download Launcher", 
                        Url = "https://github.com/ngshp/Launcher1/releases/latest" 
                    } 
                }
            });
        }

        public void Dispose() => client?.Dispose();
    }
}
