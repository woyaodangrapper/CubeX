using Microsoft.UI.Xaml;
using System;

namespace PalpsL.Windows;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        try
        {
            new UpdaterWindow().Activate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FATAL ERROR ON APP INITIALIZER LEVEL!!!\r\n{ex}");
            Console.WriteLine("\r\nIf this is not intended, please report it to: https://github.com/neon-nyan/XLauncher/issues\r\nPress any key to exit...");
            Console.ReadLine();
        }


    }
}