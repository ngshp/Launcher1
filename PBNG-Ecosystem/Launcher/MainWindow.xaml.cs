using System.Windows;
using System.Windows.Controls;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public partial class MainWindow : Window
    {
        private DiscordService _discord = new();
        private UpdaterService _updater = new();
        private LanguageService _lang = LanguageService.Instance;

        public MainWindow()
        {
            _lang.LoadSavedLang();
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += (s, e) => _discord.Dispose();
            _lang.OnLanguageChanged += UpdateUI;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Set combo to current lang - FIXED
            try
            {
                foreach (ComboBoxItem item in LangCombo.Items)
                {
                    if ((string)item.Tag == _lang.CurrentLang)
                    {
                        LangCombo.SelectedItem = item;
                        break;
                    }
                }
            } catch {}
            
            UpdateUI();

            try { _discord.Init(); _discord.SetPresence(_lang.T("in_launcher"), _lang.T("ready")); } catch {}

            try
            {
                var (hasUpdate, ver, url, size) = await _updater.CheckAsync();
                if (hasUpdate)
                {
                    var res = System.Windows.MessageBox.Show($"{_lang.T("update_available")} v{ver} ({size / 1024 / 1024} MB)\n{_lang.T("update_now")}", "PBNG Launcher", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (res == MessageBoxResult.Yes)
                    {
                        _discord.SetPresence($"Updating to v{ver}", _lang.T("downloading"));
                        await _updater.DownloadAndInstallAsync(url);
                    }
                }
            }
            catch {}
        }

        private void LangCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LangCombo.SelectedItem is ComboBoxItem item && item.Tag is string code)
            {
                _lang.SetLanguage(code);
            }
        }

        private void UpdateUI()
        {
            if (TitleText == null) return;
            
            TitleText.Text = _lang.T("app_title");
            SubtitleText.Text = _lang.T("app_subtitle");
            LaunchButton.Content = _lang.T("launch");
            SuccessText.Text = _lang.T("success");
            DiscordText.Text = $"{_lang.T("discord_on")} • {_lang.T("updater_on")}";
            WelcomeText.Text = _lang.T("welcome") + " - PBNG Ecosystem";
            LangLabel.Text = $"🌐 {_lang.T("language")}:";
            VersionText.Text = $"{_lang.T("version")} 1.0.104";
            VerifiedText.Text = _lang.T("verified");
            
            try { _discord.SetPresence(_lang.T("in_launcher"), _lang.T("ready")); } catch {}
        }
    }
}
