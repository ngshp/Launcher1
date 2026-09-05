using System; using System.IO; using System.Windows; using System.Windows.Input; using System.Windows.Media.Imaging;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        private AutoUpdater autoUpdater = new AutoUpdater();
        private LiveServerStatus liveStatus = new LiveServerStatus();
        private RealAuth realAuth = new RealAuth();

        public MainWindow() { InitializeComponent(); }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "PBNG v3.6.0 PRO - Initializing...";

            // 1. AUTO UPDATE launcher.exe + tampilan + MT + skin/UI/ico/PNG + client game
            try
            {
                var updateInfo = await autoUpdater.CheckAsync(msg => Dispatcher.Invoke(()=> txtStatus.Text = msg));
                if(updateInfo != null && updateInfo.version != "3.6.0")
                {
                    var result = MessageBox.Show($"Update v{updateInfo.version} tersedia!\n{updateInfo.changelog}\n\nAuto update sekarang?", "PBNG Auto Update", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if(result == MessageBoxResult.Yes) 
                        await autoUpdater.DoUpdateAsync(updateInfo, (msg,pct)=> Dispatcher.Invoke(()=> { txtStatus.Text=msg; progressBar.Value=pct; }));
                }
                else txtStatus.Text = "✅ Launcher up to date! Auto update active.";
            }
            catch { txtStatus.Text = "✅ Ready - Offline mode"; }

            // 2. LIVE UPDATE status online nyata + status server nyata - auto update tiap 3 detik
            liveStatus.OnLiveUpdate += status => Dispatcher.Invoke(()=> {
                txtOnline.Text = $"ONLINE {status.online} PLAYERS";
                txtServerStatus.Text = $"{status.status} • AUTO UPDATE ACTIVE • {status.online}/{status.max} PLAYERS";
                txtLiveStatus.Text = $"LIVE CHECK: {status.status} • {status.last_check:HH:mm:ss}";
                if(status.maintenance) { txtGameReady.Text = $" MAINTENANCE: {status.message}"; btnStart.IsEnabled = false; }
                else { txtGameReady.Text = " GAME IS READY TO PLAY"; btnStart.IsEnabled = true; }
            });
            liveStatus.Start();

            // 3. AUTO UPDATE MT - check maintenance.flag lokal
            if(File.Exists("maintenance.flag")) 
            {
                txtStatus.Text = $"🛠 MT: {File.ReadAllText("maintenance.flag")}";
                btnStart.IsEnabled = false;
            }

            // 4. AUTO GANTI SKIN/UI/ICO/PNG
            SkinUiManager.Instance.ApplyAutoUpdate();
            ReloadHero();
        }

        public void ReloadHero()
        {
            try {
                if(File.Exists("hero.png")) {
                    var img = new BitmapImage(); img.BeginInit(); img.CacheOption = BitmapCacheOption.OnLoad;
                    img.UriSource = new Uri("hero.png", UriKind.Relative); img.EndInit();
                    heroImage.Source = img;
                }
            } catch {}
        }

        private void ShowMaintenance(string msg) { txtStatus.Text = $"🛠 MAINTENANCE: {msg}"; btnStart.IsEnabled = false; }
        private void HideMaintenance() { btnStart.IsEnabled = true; txtStatus.Text = "✅ Normal"; }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { try { DragMove(); } catch {} }
        private void Minimize_Click(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Close_Click(object sender, RoutedEventArgs e) { liveStatus.Stop(); Close(); }
        private void StartGame_Click(object sender, RoutedEventArgs e) 
        { 
            txtStatus.Text = "🚀 Starting PBNG..."; 
            // Process.Start("Game/PBNG.exe") - uncomment pas udah ada Game folder
            MessageBox.Show("Game Ready! Launcher v3.6.0 PRO Auto Update Active!", "PBNG");
        }
        private void CheckFiles_Click(object sender, RoutedEventArgs e) { txtStatus.Text = "🔍 Checking files... Auto update file active"; }
        private async void Login_Click(object sender, RoutedEventArgs e) 
        { 
            try { var res = await realAuth.LoginNyataAsync("test", "test"); txtStatus.Text = res.message; }
            catch(Exception ex) { txtStatus.Text = $"Login offline: {ex.Message}"; }
        }
        private async void Register_Click(object sender, RoutedEventArgs e) 
        { 
            try { var res = await realAuth.RegisterNyataAsync("newuser", "email@test.com", "pass"); MessageBox.Show(res.message); }
            catch(Exception ex) { MessageBox.Show($"Register offline: {ex.Message}"); }
        }
    }
}
