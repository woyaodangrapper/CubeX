using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using WinRT;

namespace PalpsL.Windows;

public static class MainEntryPoint
{
    [DllImport("Microsoft.ui.xaml.dll")]
    private static extern void XamlCheckProcessRequirements();

    [STAThread]
    public static void Main(params string[] args)
    {
        try
        {
            Console.WriteLine("Starting application...");
            XamlCheckProcessRequirements();
            Console.WriteLine("XamlCheckProcessRequirements passed.");

            ComWrappersSupport.InitializeComWrappers();
            Console.WriteLine("ComWrappers initialized.");

            Application.Start((p) =>
            {
                DispatcherQueueSynchronizationContext context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                SynchronizationContext.SetSynchronizationContext(context);
                Console.WriteLine("Synchronization context set.");

                new App();
                Console.WriteLine("App instance created.");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }


}
