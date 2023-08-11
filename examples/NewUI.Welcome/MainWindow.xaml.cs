using Hi3Helper;
using NewUI.Welcome.Extensions;
using System.Diagnostics;

namespace Welcome
{
    public sealed partial class MainWindow : Window
    {
        private readonly ApplicationWindowInfo _windowDefault = WindowDefaultDependency.Instance;

        //private IntPtr _windowHandle = IntPtr.Zero;
        //private Windows.Foundation.Rect? _windowPosSize = null;
        //private OverlappedPresenter? _presenter = null;
        //private AppWindow? _appWindow = null;

        public MainWindow()
        {
            InitializeComponent();
            _windowDefault.RootFrame = rootFrame;
        }

        public void InitializeWindow()
        {
            Activate();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var windowHandle = _windowDefault.WindowHandle = InvokeProp.GetActiveWindow();
            var appWindow = _windowDefault.ApplicationWindow = AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(windowHandle));
            var presenter = _windowDefault.Presenter = (OverlappedPresenter?)appWindow.Presenter;

            appWindow.TitleBar.ButtonForegroundColor = new Windows.UI.Color { A = 255, B = 255, G = 255, R = 255 };
            appWindow.TitleBar.ButtonHoverBackgroundColor = new Windows.UI.Color { A = 64, B = 0, G = 0, R = 0 };

            appWindow.TitleBar.ButtonBackgroundColor = new Windows.UI.Color { A = 0, B = 0, G = 0, R = 0 };
            appWindow.TitleBar.ButtonInactiveBackgroundColor = new Windows.UI.Color { A = 0, B = 0, G = 0, R = 0 };

            appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            appWindow.TitleBar.IconShowOptions = IconShowOptions.HideIconAndSystemMenu;
            appWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;

            presenter!.IsResizable = false;
            presenter!.IsMaximizable = false;

            Application.Current.Resources["WindowCaptionForeground"] = new Windows.UI.Color { A = 255, B = 255, G = 255, R = 255 };
            Application.Current.Resources["WindowCaptionBackground"] = new SolidColorBrush(new Windows.UI.Color { A = 0, B = 0, G = 0, R = 0 });
            Application.Current.Resources["WindowCaptionBackgroundDisabled"] = new SolidColorBrush(new Windows.UI.Color { A = 0, B = 0, G = 0, R = 0 });

            int gwl_style = -16;
            uint minimizeBtn = 0x00020000;
            uint maximizeBtn = 0x00010000;
            var currentStyle = InvokeProp.GetWindowLong(windowHandle, gwl_style);
            InvokeProp.SetWindowLong(windowHandle, gwl_style, currentStyle & ~minimizeBtn & ~maximizeBtn);
            _windowDefault.WindowHandle.WindowSize(WindowSize.CurrentWindowSize.WindowBounds.Width, WindowSize.CurrentWindowSize.WindowBounds.Height);

            rootFrame.Navigate(typeof(Windows.Welcome), null, new DrillInNavigationTransitionInfo());

            // 结束计时
            stopwatch.Stop();
            Logger.LogWriteLine(string.Format("Form Start Time [{0}]",
              stopwatch.Elapsed), LogType.Debug, true);
        }
    }
}