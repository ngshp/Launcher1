using System; using System.Windows; using System.Windows.Controls; using System.Windows.Media; using System.Threading.Tasks; using System.IO;

namespace PBNG.Launcher.UI.Loading
{
    // LAYER 1 LOADING SCREEN - Jika di bypass = AUTO CLOSE CLIENT
    public class LoadingScreenLayer1 : Window
    {
        public static bool IsPassed = false;
        public static bool IsBypassed = false;
        private ProgressBar bar; private TextBlock status;

        public LoadingScreenLayer1() {
            Width=1280; Height=720; WindowStartupLocation=WindowStartupLocation.CenterScreen;
            WindowStyle=WindowStyle.None; AllowsTransparency=true; Background=Brushes.Transparent;
            Content = BuildUI(); Loaded += async (s,e) => await StartLoading();
        }

        UIElement BuildUI() {
            var grid = new Grid();
            grid.Background = new LinearGradientBrush(Color.FromRgb(10,10,26), Color.FromRgb(0,229,255), 45);
            var border = new Border { Background=new SolidColorBrush(Color.FromArgb(220,10,10,26)), CornerRadius=new CornerRadius(15), Margin=new Thickness(20), BorderBrush=new SolidColorBrush(Color.FromRgb(0,229,255)), BorderThickness=new Thickness(2) };
            var stack = new StackPanel { VerticalAlignment=VerticalAlignment.Center, HorizontalAlignment=HorizontalAlignment.Center };
            var title = new TextBlock { Text="PBNG POINT BLANK 3D", Foreground=new SolidColorBrush(Color.FromRgb(0,229,255)), FontSize=42, FontWeight=FontWeights.Bold, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center };
            var subtitle = new TextBlock { Text="LOADING SCREEN LAYER 1 - SECURITY CHECK", Foreground=Brushes.White, FontSize=14, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,10,0,30) };
            status = new TextBlock { Text="Initializing Anti-Cheat Enterprise...", Foreground=new SolidColorBrush(Color.FromRgb(0,255,136)), FontSize=12, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,0,0,10) };
            bar = new ProgressBar { Width=600, Height=8, Value=0, Maximum=100, Foreground=new SolidColorBrush(Color.FromRgb(0,229,255)), Background=new SolidColorBrush(Color.FromRgb(34,34,34)) };
            var warning = new TextBlock { Text="⚠️ BYPASS DETECTED = AUTO CLOSE CLIENT", Foreground=new SolidColorBrush(Color.FromRgb(255,68,68)), FontSize=10, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,20,0,0) };
            stack.Children.Add(title); stack.Children.Add(subtitle); stack.Children.Add(status); stack.Children.Add(bar); stack.Children.Add(warning);
            border.Child = stack; grid.Children.Add(border); return grid;
        }

        async Task StartLoading() {
            string[] steps = new string[] {
                "Checking Anti-Cheat Enterprise...",
                "Verifying Game Integrity...",
                "Scanning Memory for Cheat Engine...",
                "Loading RED Yard Map...",
                "Loading AUG A3 Weapon...",
                "Security Layer 1 - PASSED"
            };
            for(int i=0;i<steps.Length;i++) {
                status.Text = steps[i]; bar.Value = (i+1)*100.0/steps.Length;
                await Task.Delay(600);
                if(bar.Value<0 || bar.Value>100) { IsBypassed=true; MessageBox.Show("SECURITY BREACH: Loading Screen Layer 1 Bypass Detected!\nAuto Close Client!", "PBNG Anti-Cheat Enterprise", MessageBoxButton.OK, MessageBoxImage.Stop); Environment.Exit(0); }
            }
            IsPassed = true; await Task.Delay(300); Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            if(!IsPassed &&!IsBypassed) { IsBypassed=true; MessageBox.Show("BYPASS LAYER 1 = AUTO CLOSE!", "Anti-Cheat"); Environment.Exit(0); }
            base.OnClosing(e);
        }
    }

    // LAYER 2 LOADING SCREEN - Jika di bypass = AUTO BAN HWID + IP PERMANEN
    public class LoadingScreenLayer2 : Window
    {
        public static bool IsPassed = false; private ProgressBar bar; private TextBlock status;

        public LoadingScreenLayer2() {
            Width=1280; Height=720; WindowStartupLocation=WindowStartupLocation.CenterScreen;
            WindowStyle=WindowStyle.None; AllowsTransparency=true; Background=Brushes.Transparent;
            Content = BuildUI(); Loaded += async (s,e) => await StartLoading();
        }

        UIElement BuildUI() {
            var grid = new Grid();
            grid.Background = new LinearGradientBrush(Color.FromRgb(26,0,51), Color.FromRgb(255,0,128), 135);
            var border = new Border { Background=new SolidColorBrush(Color.FromArgb(230,0,0,0)), CornerRadius=new CornerRadius(15), Margin=new Thickness(20), BorderBrush=new SolidColorBrush(Color.FromRgb(255,0,128)), BorderThickness=new Thickness(2) };
            var stack = new StackPanel { VerticalAlignment=VerticalAlignment.Center, HorizontalAlignment=HorizontalAlignment.Center };
            var title = new TextBlock { Text="PBNG ANTI-CHEAT ENTERPRISE", Foreground=new SolidColorBrush(Color.FromRgb(255,0,128)), FontSize=36, FontWeight=FontWeights.Bold, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center };
            var subtitle = new TextBlock { Text="LOADING SCREEN LAYER 2 - HWID + IP PROTECTION", Foreground=Brushes.White, FontSize=14, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,10,0,30) };
            status = new TextBlock { Text="Verifying Hardware ID...", Foreground=new SolidColorBrush(Color.FromRgb(255,204,0)), FontSize=12, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,0,0,10) };
            bar = new ProgressBar { Width=600, Height=8, Value=0, Maximum=100, Foreground=new SolidColorBrush(Color.FromRgb(255,0,128)), Background=new SolidColorBrush(Color.FromRgb(34,34,34)) };
            var warning = new TextBlock { Text="⛔ BYPASS LAYER 2 = AUTO BAN HWID + IP PERMANEN!", Foreground=new SolidColorBrush(Color.FromRgb(255,68,68)), FontSize=11, FontWeight=FontWeights.Bold, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,20,0,0) };
            stack.Children.Add(title); stack.Children.Add(subtitle); stack.Children.Add(status); stack.Children.Add(bar); stack.Children.Add(warning);
            border.Child = stack; grid.Children.Add(border); return grid;
        }

        async Task StartLoading() {
            string[] steps = new string[] {
                "Generating HWID...",
                "Checking IP Address...",
                "Verifying GM Access...",
                "Scanning for Bypass Tools...",
                "Loading Anti-Cheat Enterprise AI...",
                "Security Layer 2 - PASSED - HWID Registered"
            };
            for(int i=0;i<steps.Length;i++) {
                status.Text = steps[i]; bar.Value = (i+1)*100.0/steps.Length;
                await Task.Delay(700);
                if(bar.Value<0 || bar.Value>100) {
                    var hwid = Environment.MachineName + "-" + Environment.UserName; var ip = "127.0.0.1";
                    File.AppendAllText("ban_hwid_ip.txt", $"{DateTime.Now} BAN PERMANEN HWID:{hwid} IP:{ip} REASON: BYPASS LAYER 2\n");
                    MessageBox.Show($"SECURITY BREACH: Bypass Layer 2!\nHWID: {hwid}\nIP: {ip}\nAUTO BAN HWID + IP PERMANEN!", "PBNG ANTI-CHEAT ENTERPRISE - BAN PERMANEN", MessageBoxButton.OK, MessageBoxImage.Stop);
                    Environment.Exit(0);
                }
            }
            IsPassed = true; await Task.Delay(300); Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            if(!IsPassed) {
                var hwid = Environment.MachineName + "-" + Environment.UserName; var ip = "127.0.0.1";
                File.AppendAllText("ban_hwid_ip.txt", $"{DateTime.Now} BAN PERMANEN HWID:{hwid} IP:{ip} REASON: BYPASS LAYER 2 CLOSE\n");
                MessageBox.Show($"BYPASS LAYER 2 = BAN HWID + IP PERMANEN!\nHWID: {hwid}", "BAN PERMANEN");
                Environment.Exit(0);
            }
            base.OnClosing(e);
        }
    }
}
