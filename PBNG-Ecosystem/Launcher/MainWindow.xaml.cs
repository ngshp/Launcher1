using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        private DiscordService? _discord;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Closed += (s, e) => _discord?.Dispose();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _discord = new DiscordService();
            _discord.Init();
        }
    }
}
