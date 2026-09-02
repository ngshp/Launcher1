using System.Windows;

namespace PBNG.Launcher
{
    public partial class App : Application
    {
        public static Services.DiscordService? Discord { get; private set; }
        public static Services.UpdaterService? Updater { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Discord = new Services.DiscordService();
            Discord.Init();
            Updater = new Services.UpdaterService();

            // Buka MainWindow manual, gak pake StartupUri biar gak butuh InitializeComponent
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
