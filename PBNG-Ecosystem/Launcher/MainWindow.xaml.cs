using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        private DiscordService _discord = new();
        private UpdateService _updater = new();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += (s, e) => _discord.Dispose();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try { _discord.Init("1234567890123456789"); } catch {}

            try
            {
                var (hasUpdate, ver, url) = await _updater.CheckAsync();
                if (hasUpdate)
                {
                    var res = MessageBox.Show($"Update v{ver} tersedia! Update sekarang?", "PBNG Launcher", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (res == MessageBoxResult.Yes)
                    {
                        _discord.SetPresence($"Updating to v{ver}", "Downloading...");
                        await _updater.DownloadAndInstallAsync(url);
                    }
                }
            }
            catch {}
        }
    }
}
