using System;

namespace PBNG.Launcher.Services
{
    // VERSI TANPA DEPENDENCY - BIAR BUILD IJO DULU, DISCORD BISA DITAMBAH LAGI NANTI
    public class DiscordService : IDisposable
    {
        public void Init()
        {
            Console.WriteLine("Discord disabled for build");
        }
        public void SetPresence(string details, string state)
        {
            // No-op biar gak error
        }
        public void Dispose()
        {
        }
    }
}
