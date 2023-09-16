// See https://aka.ms/new-console-template for more information
using Hi3Helper;
using Hi3Helper.Shared.Region;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using WinRT;
using static Hi3Helper.Locale;

namespace Welcome;

public partial class Launcher
{
    private Launcher()
    {
        ComWrappersSupport.InitializeComWrappers();
    }

    [LibraryImport("Microsoft.ui.xaml.dll")]
    private static partial void XamlCheckProcessRequirements();

    [STAThread]
    public static void Main(params string[] args)
    {
        LauncherConfig.InitAppPreset();
        InitializeAppSettings();
        XamlCheckProcessRequirements();
        Logger._log = new LoggerConsole("_logs", Encoding.UTF8);
        Application.Start((p) =>
        {
            DispatcherQueueSynchronizationContext context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
            SynchronizationContext.SetSynchronizationContext(context);
            _ = new App();
        });
        return;
    }

    public static void InitializeAppSettings()
    {
        InitializeLocale();
        LoadLocale(CultureInfo.CurrentUICulture.Name);
    }
}