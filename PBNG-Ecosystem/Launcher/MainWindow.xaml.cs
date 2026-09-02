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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.Discord?.SetPresence("In PBNG Launcher", "Browsing Games");
        }
    }
}
