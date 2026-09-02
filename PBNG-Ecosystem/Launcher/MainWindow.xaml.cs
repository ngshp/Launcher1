using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        private DiscordService _discord = new();
        private UpdaterService _updater = new();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += (s, e) => _discord.Dispose();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try { _discord.Init(); } catch {}

            try
            {
                // FIX: Tuple now has 4 elements (hasUpdate, ver, url, size) not 3
                var (hasUpdate, ver, url, size) = await _updater.CheckAsync();
                if (hasUpdate)
                {
                    var res = MessageBox.Show($"Update v{ver} tersedia! ({size / 1024 / 1024} MB)\nUpdate sekarang?", "PBNG Launcher", MessageBoxButton.YesNo, MessageBoxImage.Information);
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
