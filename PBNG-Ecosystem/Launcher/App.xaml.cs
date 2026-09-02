using System.Windows;

namespace PBNG.Launcher
{
    // FIX AMBIGUOUS Application + Hapus UpdaterService yang gak ada
    public partial class App : System.Windows.Application
    {
        public static Services.DiscordService? Discord { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            Discord = new Services.DiscordService();
            Discord.Init();

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
