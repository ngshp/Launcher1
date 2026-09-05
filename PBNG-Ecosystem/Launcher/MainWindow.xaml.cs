using System.Windows;
using System.Diagnostics;
using System.IO;
namespace NGPB.Launcher {
    public partial class MainWindow : Window {
        public MainWindow(){ InitializeComponent(); }
        private void LaunchBtn_Click(object sender, RoutedEventArgs e){
            if(File.Exists("ngpb.exe")) Process.Start(new ProcessStartInfo("ngpb.exe"){UseShellExecute=true});
            else if(File.Exists("PBNG-Game-Client/ngpb.exe")) Process.Start(new ProcessStartInfo("PBNG-Game-Client/ngpb.exe"){UseShellExecute=true});
            else MessageBox.Show("ngpb.exe tidak ditemukan bos! Pastikan file game ada di folder yang sama.");
        }
    }
}
