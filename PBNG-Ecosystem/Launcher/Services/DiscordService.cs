using System;
using System.IO;

namespace PBNG.Launcher.Services
{
    public class DiscordService : IDisposable
    {
        private bool isInitialized = false;
        private string currentStatus = "Idle";

        public void Initialize()
        {
            try {
                isInitialized = true;
                File.WriteAllText("discord_presence.log", $"[{DateTime.Now}] Discord Initialized - PBNG Launcher v3.6.0 PRO");
            } catch { }
        }

        public void UpdatePresence(string status, string details)
        {
            try {
                currentStatus = status;
                File.WriteAllText("discord_presence.log", $"[{DateTime.Now}] {status} - {details}");
                // Nanti kalau mau Discord beneran, tinggal install Lachee.DiscordRPC dan uncomment
                // Client.SetPresence(...)
            } catch { }
        }

        public void SetInLauncher() => UpdatePresence("In Launcher", "PBNG v1.0.105 - Auto Update PRO");
        public void SetInGame(int online) => UpdatePresence($"Playing PBNG - {online} Online", "Tactical FPS - v3.6.0");
        public void SetInMaintenance(string msg) => UpdatePresence("Maintenance", msg);

        public void Deinitialize()
        {
            isInitialized = false;
        }

        public void Dispose()
        {
            Deinitialize();
            GC.SuppressFinalize(this);
        }
    }
}
