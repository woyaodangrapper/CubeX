using Hi3Helper;
using Microsoft.UI.Xaml.Controls;
using static Hi3Helper.Locale;
using static Hi3Helper.Logger;
using static Hi3Helper.Shared.Region.LauncherConfig;
using static XLauncher.InnerLauncherConfig;
using static XLauncher.WindowSize.WindowSize;

namespace XLauncher
{
    public sealed partial class StartupLanguageSelect : Page
    {
        private List<string> WindowSizeProfilesKey = WindowSizeProfiles.Keys.ToList();

        public StartupLanguageSelect()
        {
            try
            {
                this.InitializeComponent();
                MenuPanel.Translation += Shadow32;
            }
            catch (Exception ex)
            {
                LogWriteLine($"FATAL CRASH!!!\r\n{ex}", LogType.Error, true);
                ErrorSender.SendException(ex);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string LangID = LanguageIDIndex[(sender as ComboBox).SelectedIndex];
            SetAppConfigValue("AppLanguage", LangID);
            LoadLocale(LangID);
            NextBtn.IsEnabled = true;
        }

        private IEnumerable<string> LangList
        {
            get => LanguageNames.Select(x => $"{x.Value.LangName} ({x.Key} by {x.Value.LangAuthor})");
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e) => (m_window as MainWindow).StartSetupPage();

        private int SelectedWindowSizeProfile
        {
            get
            {
                string val = CurrentWindowSizeName;
                return WindowSizeProfilesKey.IndexOf(val);
            }
            set
            {
                CurrentWindowSizeName = WindowSizeProfilesKey[value];
            }
        }

        private int SelectedCDN
        {
            get => GetAppConfigValue("CurrentCDN").ToInt();
            set
            {
                if (value < 0) return;
                SetAppConfigValue("CurrentCDN", value);
            }
        }
    }
}