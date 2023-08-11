namespace X.Infrastructure.Caching.Configurations;

public class AppEnums
{
    public enum AppMode
    {
        Launcher,
        Updater,
        ElevateUpdater,
        InvokerMigrate,
        InvokerTakeOwnership,
        InvokerMoveSteam,
        Hi3CacheUpdater
    }

    public enum AppThemeMode
    {
        Default = 0,
        Light = 1,
        Dark = 2,
    }
}