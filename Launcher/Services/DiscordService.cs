using System;
using DiscordRPC;

namespace PBNG.Launcher.Services
{
    public class DiscordService : IDisposable
    {
        private DiscordRpcClient? client;
        public void Init(string clientId = "1234567890123456789")
        {
            client = new DiscordRpcClient(clientId);
            client.Initialize();
            SetPresence("In PBNG Launcher", "Browsing Ecosystem");
        }
        public void SetPresence(string details, string state)
        {
            if (client == null) return;
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Timestamps = new Timestamps { Start = DateTime.UtcNow },
                Assets = new Assets { LargeImageKey = "pbng_icon", LargeImageText = "PBNG Launcher v1.0.36" },
                Buttons = new[] { new Button { Label = "Download", Url = "https://github.com/ngshp/Launcher1/releases/latest" } }
            });
        }
        public void Dispose() => client?.Dispose();
    }
}
