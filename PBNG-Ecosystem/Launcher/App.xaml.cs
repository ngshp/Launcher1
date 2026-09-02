using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class App : Application
    {
        public static DiscordService Discord { get; private set; }
        public static UpdateService Updater { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Discord = new DiscordService();
            Updater = new UpdateService();

            try { Discord.Init("1234567890123456789"); } catch {}

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Discord?.Dispose();
            base.OnExit(e);
        }
    }
}
