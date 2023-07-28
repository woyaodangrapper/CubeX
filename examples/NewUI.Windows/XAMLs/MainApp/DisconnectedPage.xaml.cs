using XLauncher.Pages;
using Hi3Helper;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using static Hi3Helper.Logger;

namespace XLauncher
{
    public sealed partial class DisconnectedPage : Page
    {
        public DisconnectedPage()
        {
            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                LogWriteLine($"FATAL CRASH!!!\r\n{ex}", LogType.Error, true);
                ErrorSender.SendException(ex);
            }
        }

        private void PaimonClicked(object sender, PointerRoutedEventArgs e)
        {
            MainFrameChanger.ChangeWindowFrame(typeof(MainPage), new DrillInNavigationTransitionInfo());
        }

        private void ShowError(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            MainFrameChanger.ChangeWindowFrame(typeof(UnhandledExceptionPage));
        }
    }
}