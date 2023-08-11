﻿using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using static Hi3Helper.Locale;
using static XLauncher.InnerLauncherConfig;

namespace XLauncher.Pages
{
    public sealed partial class UnhandledExceptionPage : Page
    {
        public UnhandledExceptionPage()
        {
            this.InitializeComponent();
            ExceptionTextBox.Text = ErrorSender.ExceptionContent;
            Title.Text = ErrorSender.ExceptionTitle;
            Subtitle.Text = ErrorSender.ExceptionSubtitle;

            if ((ErrorSender.ExceptionType == ErrorType.Connection) && (m_window as MainWindow).rootFrame.CanGoBack)
                BackToPreviousPage.Visibility = Visibility.Visible;
        }

        private void GoBackPreviousPage(object sender, RoutedEventArgs e) => (m_window as MainWindow).rootFrame.GoBack();

        private void CopyTextToClipboard(object sender, RoutedEventArgs e)
        {
            DataPackage data = new DataPackage()
            {
                RequestedOperation = DataPackageOperation.Copy
            };
            data.SetText(ErrorSender.ExceptionContent);
            Clipboard.SetContent(data);
            CopyThrow.Content = Lang._UnhandledExceptionPage.CopyClipboardBtn2;
            CopyThrow.IsEnabled = false;
        }
    }
}