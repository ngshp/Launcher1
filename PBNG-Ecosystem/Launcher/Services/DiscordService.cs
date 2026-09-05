using System;

namespace PBNG.Launcher.Services
{
    public class DiscordService : IDisposable
    {
        public void Initialize() { /* Discord disabled for build */ }
        public void UpdatePresence(string status, string details) { }
        public void Dispose() { }
        public void Deinitialize() { }
    }
}
