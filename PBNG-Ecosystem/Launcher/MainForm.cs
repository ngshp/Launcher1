using System.Windows;

namespace PBNG.Launcher
{
    // FIXED: Gak manggil InitializeComponent karena gak ada MainForm.xaml
    // File ini TETAP ADA sesuai permintaan Toko!
    public partial class MainForm : Window
    {
        public MainForm()
        {
            // Jangan panggil InitializeComponent - bikin Window kosong aja
            this.Title = "PBNG MainForm (Legacy)";
            this.Width = 400;
            this.Height = 300;
            this.Loaded += MainForm_Loaded;
        }

        private async void MainForm_Loaded(object sender, RoutedEventArgs e)
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
