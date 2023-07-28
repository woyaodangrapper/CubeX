using XLauncher.GameSettings.Base;
using XLauncher.GameSettings.Universal;

namespace XLauncher.Interfaces
{
    internal interface IGameSettingsUniversal
    {
        BaseScreenSettingData SettingsScreen { get; set; }
        CollapseScreenSetting SettingsCollapseScreen { get; set; }
        CustomArgs SettingsCustomArgument { get; set; }
    }
}
