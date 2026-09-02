using System;
using System.Windows;

namespace PBNG.Launcher
{
    public partial class App : System.Windows.Application
    {
        public static Services.DiscordService? Discord { get; private set; }
        public static Services.UpdaterService? Updater { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            Discord = new Services.DiscordService();
            Discord.Init();
            Updater = new Services.UpdaterService();

            var main = new MainWindow();
            main.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Discord?.Dispose();
            base.OnExit(e);
        }
    }
}
