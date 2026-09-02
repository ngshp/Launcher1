using System;
using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Discord presence update
            App.Discord?.SetPresence("In PBNG Launcher", "Browsing Games");

            // Check update dari GitHub
            try
            {
                var (hasUpdate, latestVer, downloadUrl) = await App.Updater.CheckAsync();
                if (hasUpdate)
                {
                    var result = MessageBox.Show(
                        $"Update v{latestVer} tersedia!\nMau update sekarang?",
                        "PBNG Launcher - Update Available",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Information);

                    if (result == MessageBoxResult.Yes)
                    {
                        App.Discord?.SetPresence($"Updating to v{latestVer}", "Downloading...");
                        await App.Updater.DownloadAndInstallAsync(downloadUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update check failed: " + ex.Message);
            }
        }
    }
}
