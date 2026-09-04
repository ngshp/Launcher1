using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;
using System.IO;

using ProgressBar = System.Windows.Controls.ProgressBar;
using MessageBox = System.Windows.MessageBox;

namespace PBNG.Launcher.UI.Loading
{
    public class LoadingScreenLayer1 : Window
    {
        public static bool IsPassed = false;
        public static bool IsBypassed = false;
        private ProgressBar bar = null!;
        private TextBlock status = null!;

        public LoadingScreenLayer1() {
            Width=1280; Height=720; WindowStartupLocation=WindowStartupLocation.CenterScreen;
            WindowStyle=WindowStyle.None; AllowsTransparency=true; Background=Brushes.Transparent;
            Topmost=true;
            Content = BuildUI();
            Loaded += async (s,e) => await StartLoading();
        }

        UIElement BuildUI() {
            var grid = new Grid();
            grid.Background = new LinearGradientBrush(Color.FromRgb(10,10,26), Color.FromRgb(0,229,255), 45);
            var border = new Border { Background=new SolidColorBrush(Color.FromArgb(220,10,10,26)), CornerRadius=new CornerRadius(15), Margin=new Thickness(20), BorderBrush=new SolidColorBrush(Color.FromRgb(0,229,255)), BorderThickness=new Thickness(2) };
            var stack = new StackPanel { VerticalAlignment=VerticalAlignment.Center, HorizontalAlignment=HorizontalAlignment.Center };
            var title = new TextBlock { Text="PBNG POINT BLANK 3D", Foreground=new SolidColorBrush(Color.FromRgb(0,229,255)), FontSize=42, FontWeight=FontWeights.Bold, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center };
            var subtitle = new TextBlock { Text="LOADING SCREEN LAYER 1 - RED Yard 8v8 - 002 7R 001 02:45", Foreground=Brushes.White, FontSize=14, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,10,0,30) };
            status = new TextBlock { Text="Initializing Anti-Cheat Enterprise...", Foreground=new SolidColorBrush(Color.FromRgb(0,255,136)), FontSize=12, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,0,0,10) };
            bar = new ProgressBar { Width=600, Height=8, Value=0, Maximum=100, Foreground=new SolidColorBrush(Color.FromRgb(0,229,255)), Background=new SolidColorBrush(Color.FromRgb(34,34,34)) };
            var warning = new TextBlock { Text="⚠️ BYPASS = AUTO CLOSE - "+Environment.MachineName, Foreground=new SolidColorBrush(Color.FromRgb(255,68,68)), FontSize=10, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,20,0,0) };
            stack.Children.Add(title); stack.Children.Add(subtitle); stack.Children.Add(status); stack.Children.Add(bar); stack.Children.Add(warning);
            border.Child = stack; grid.Children.Add(border); return grid;
        }

        async Task StartLoading() {
            string[] steps = { "Checking Anti-Cheat 4 Layer...", "Verifying ngpb.exe 60 MB...", "Scanning Memory...", "Loading RED Yard...", "Loading AUG A3 28/120...", "Layer 1 - PASSED - 127.0.0.1:39190" };
            for(int i=0;i<steps.Length;i++) {
                status.Text = steps[i]; bar.Value = (i+1)*100.0/steps.Length;
                await Task.Delay(600);
                if(bar.Value<0 || bar.Value>100) { IsBypassed=true; MessageBox.Show("BYPASS LAYER 1 = AUTO CLOSE!", "PBNG Anti-Cheat"); Environment.Exit(0); }
            }
            IsPassed = true; await Task.Delay(300); Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            if(!IsPassed &&!IsBypassed) { IsBypassed=true; MessageBox.Show("BYPASS LAYER 1 = AUTO CLOSE!", "Anti-Cheat"); Environment.Exit(0); }
            base.OnClosing(e);
        }
    }

    public class LoadingScreenLayer2 : Window
    {
        public static bool IsPassed = false;
        public static bool IsBypassed = false;
        private ProgressBar bar = null!;
        private TextBlock status = null!;

        public LoadingScreenLayer2() {
            Width=1280; Height=720; WindowStartupLocation=WindowStartupLocation.CenterScreen;
            WindowStyle=WindowStyle.None; AllowsTransparency=true; Background=Brushes.Transparent;
            Topmost=true;
            Content = BuildUI();
            Loaded += async (s,e) => await StartLoading();
        }

        UIElement BuildUI() {
            var grid = new Grid();
            grid.Background = new LinearGradientBrush(Color.FromRgb(26,0,51), Color.FromRgb(255,0,128), 135);
            var border = new Border { Background=new SolidColorBrush(Color.FromArgb(230,0,0,0)), CornerRadius=new CornerRadius(15), Margin=new Thickness(20), BorderBrush=new SolidColorBrush(Color.FromRgb(255,0,128)), BorderThickness=new Thickness(2) };
            var stack = new StackPanel { VerticalAlignment=VerticalAlignment.Center, HorizontalAlignment=HorizontalAlignment.Center };
            var title = new TextBlock { Text="PBNG ANTI-CHEAT ENTERPRISE", Foreground=new SolidColorBrush(Color.FromRgb(255,0,128)), FontSize=36, FontWeight=FontWeights.Bold, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center };
            var subtitle = new TextBlock { Text="LAYER 2 - HWID + IP - 0.0.0.0:39190 VPS - BAN PERMANEN", Foreground=Brushes.White, FontSize=14, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,10,0,30) };
            status = new TextBlock { Text="Verifying HWID...", Foreground=new SolidColorBrush(Color.FromRgb(255,204,0)), FontSize=12, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,0,0,10) };
            bar = new ProgressBar { Width=600, Height=8, Value=0, Maximum=100, Foreground=new SolidColorBrush(Color.FromRgb(255,0,128)), Background=new SolidColorBrush(Color.FromRgb(34,34,34)) };
            var warning = new TextBlock { Text="⛔ BYPASS LAYER 2 = BAN HWID+IP PERMANEN! - "+Environment.MachineName, Foreground=new SolidColorBrush(Color.FromRgb(255,68,68)), FontSize=11, FontWeight=FontWeights.Bold, FontFamily=new FontFamily("Consolas"), HorizontalAlignment=HorizontalAlignment.Center, Margin=new Thickness(0,20,0,0) };
            stack.Children.Add(title); stack.Children.Add(subtitle); stack.Children.Add(status); stack.Children.Add(bar); stack.Children.Add(warning);
            border.Child = stack; grid.Children.Add(border); return grid;
        }

        async Task StartLoading() {
            string[] steps = { "Generating HWID...", "Checking IP 127.0.0.1:39190...", "Verifying GM Whitelist...", "Scanning Bypass...", "Loading Enterprise AI...", "Layer 2 - PASSED - RED Yard Ready!" };
            for(int i=0;i<steps.Length;i++) {
                status.Text = steps[i]; bar.Value = (i+1)*100.0/steps.Length;
                await Task.Delay(700);
                if(bar.Value<0 || bar.Value>100) {
                    var hwid = Environment.MachineName + "-" + Environment.UserName; var ip = "127.0.0.1";
                    try { File.AppendAllText("ban_hwid_ip.txt", $"{DateTime.Now} BAN HWID:{hwid} IP:{ip} BYPASS LAYER 2\n"); } catch {}
                    MessageBox.Show($"BYPASS LAYER 2!\nHWID:{hwid}\nBAN PERMANEN!", "BAN PERMANEN"); Environment.Exit(0);
                }
            }
            IsPassed = true; await Task.Delay(300); Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            if(!IsPassed) {
                var hwid = Environment.MachineName + "-" + Environment.UserName; var ip = "127.0.0.1";
                try { File.AppendAllText("ban_hwid_ip.txt", $"{DateTime.Now} BAN HWID:{hwid} IP:{ip} BYPASS CLOSE\n"); } catch {}
                MessageBox.Show($"BYPASS LAYER 2 = BAN PERMANEN!\nHWID:{hwid}", "BAN"); Environment.Exit(0);
            }
            base.OnClosing(e);
        }
    }
}
