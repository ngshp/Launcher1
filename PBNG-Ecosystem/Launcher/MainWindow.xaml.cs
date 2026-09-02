using System;
using System.Windows;
using System.Windows.Controls;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Title = "PBNG Launcher";
            this.Width = 900;
            this.Height = 600;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var grid = new Grid();
            var text = new TextBlock
            {
                Text = "PBNG Launcher - Build SUCCESS! 💚",
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 24
            };
            grid.Children.Add(text);
            this.Content = grid;

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
