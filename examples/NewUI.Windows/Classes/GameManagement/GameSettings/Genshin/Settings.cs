using XLauncher.GameSettings.Base;
using XLauncher.GameSettings.Genshin;
using XLauncher.GameSettings.Universal;
using XLauncher.Interfaces;
using XLauncher.Statics;
using Microsoft.Win32;
using System.IO;
using static XLauncher.GameSettings.Statics;

namespace XLauncher.GameSettings.Genshin
{
    internal class GenshinSettings : ImportExportBase, IGameSettings, IGameSettingsUniversal
    {
        public CustomArgs SettingsCustomArgument { get; set; }
        public BaseScreenSettingData SettingsScreen { get; set; }
        public CollapseScreenSetting SettingsCollapseScreen { get; set; }
        public GeneralData SettingsGeneralData { get; set; }

        public GenshinSettings()
        {
            // Init Root Registry Key
            RegistryPath = Path.Combine(RegistryRootPath, PageStatics._GameVersion.GamePreset.InternalGameNameInConfig);
            RegistryRoot = Registry.CurrentUser.OpenSubKey(RegistryPath, true);

            // If the Root Registry Key is null (not exist), then create a new one.
            if (RegistryRoot == null)
            {
                RegistryRoot = Registry.CurrentUser.CreateSubKey(RegistryPath, true, RegistryOptions.None);
            }

            // Initialize and Load Settings
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            // Load Settings
            SettingsCustomArgument = CustomArgs.Load();
            SettingsCollapseScreen = CollapseScreenSetting.Load();
            SettingsScreen = ScreenManager.Load();
            SettingsGeneralData = GeneralData.Load();
        }

        public void ReloadSettings() => InitializeSettings();

        public void SaveSettings()
        {
            // Save Settings
            SettingsCustomArgument.Save();
            SettingsCollapseScreen.Save();
            SettingsScreen.Save();
            SettingsGeneralData.Save();
        }

        public IGameSettingsUniversal AsIGameSettingsUniversal() => this;
    }
}
