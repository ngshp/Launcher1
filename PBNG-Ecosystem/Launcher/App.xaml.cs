using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    // FIX: Pakai System.Windows.Application biar gak bentrok sama WinForms
    public partial class App : System.Windows.Application
    {
        public static DiscordService? Discord { get; private set; }
        public static UpdateService? Updater { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Discord = new DiscordService();
            Discord.Init();
            Updater = new UpdateService();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Discord?.Dispose();
            base.OnExit(e);
        }
    }
}
