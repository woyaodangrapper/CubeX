// See https://aka.ms/new-console-template for more information

using Hi3Helper;
using Hi3Helper.Shared.Region;
using Squirrel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WinRT;

namespace Welcome;

public partial class Launcher
{
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvStdcall) })]
    [LibraryImport("Microsoft.ui.xaml.dll", SetLastError = true, EntryPoint = "XamlCheckProcessRequirements")]
    private static partial void XamlCheckProcessRequirements();

    [STAThread]
    public static void Main(params string[] args)
    {
#if PREVIEW
        LauncherConfig.IsPreview = true;
#endif
        StartSquirrelHook();

        Logger._log = new LoggerConsole("_logs", Encoding.UTF8);

        Logger.LogWriteLine("test", LogType.Scheme, true);

        if (!DecideRedirection())
        {
            XamlCheckProcessRequirements();
            ComWrappersSupport.InitializeComWrappers();
            Application.Start((p) =>
            {
                DispatcherQueueSynchronizationContext context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                SynchronizationContext.SetSynchronizationContext(context);
                _ = new App();
            });
        }
        return;
    }

    private static bool DecideRedirection()
    {
        return false;
    }

    private static void StartSquirrelHook()
    {
        // Add Squirrel Hooks
        SquirrelAwareApp.HandleEvents(
            /// Add shortcut and uninstaller entry on first start-up
            onInitialInstall: (_, sqr) =>
            {
                Console.WriteLine("Please do not close this console window while CubeX is preparing the installation via Squirrel...");
            },
            onAppUpdate: (_, sqr) =>
            {
                Console.WriteLine("Please do not close this console window while CubeX is updating via Squirrel...");
            },
            onAppUninstall: (_, sqr) =>
            {
                Console.WriteLine("Uninstalling CubeX via Squirrel...\r\nPlease do not close this console window while action is being performed!");
            },
            onEveryRun: (_, _, _) => { }
        );
    }
}