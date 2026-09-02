using System;
using System.Windows;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.Discord?.SetPresence("In PBNG Launcher", "Browsing Games");
            try
            {
                if (App.Updater != null)
                {
                    var (hasUpdate, latestVer, downloadUrl) = await App.Updater.CheckAsync();
                    if (hasUpdate)
                    {
                        // FIX: Pakai System.Windows.MessageBox biar gak bentrok sama WinForms
                        var result = System.Windows.MessageBox.Show(
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update check failed: " + ex.Message);
            }
        }
    }
}
