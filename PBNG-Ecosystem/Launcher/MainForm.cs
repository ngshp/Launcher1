using System.Windows;

namespace PBNG.Launcher
{
    public partial class MainForm : Window
    {
        public MainForm()
        {
            this.Title = "PBNG MainForm (Legacy)";
            this.Width = 400;
            this.Height = 300;
            this.Loaded += MainForm_Loaded;
        }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            App.Discord?.SetPresence("In PBNG Launcher", "Browsing Games");
        }
    }
}
