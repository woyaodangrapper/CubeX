using Microsoft.UI.Xaml.Media;
using Windows.Graphics;

namespace Welcome
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        public void InitializeWindowProperties()
        {
            InitializeWindowSettings();
        }

        public void StartSetupPage()
        {
        }

        public void StartMainPage()
        {
        }

        private void InitializeAppWindowAndIntPtr()
        {
            this.InitializeComponent();
            this.Activate();
            RunSetDragAreaQueue();
        }

        private void LoadWindowIcon()
        {
        }

        public void InitializeWindowSettings()
        {
            InitializeAppWindowAndIntPtr();
            LoadWindowIcon();
        }

        private void SetLegacyTitleBarColor()
        {
            Application.Current.Resources["WindowCaptionForeground"] = new Windows.UI.Color { A = 255, B = 0, G = 0, R = 0 };
            Application.Current.Resources["WindowCaptionBackground"] = new SolidColorBrush(new Windows.UI.Color { A = 0, B = 0, G = 0, R = 0 });
            Application.Current.Resources["WindowCaptionBackgroundDisabled"] = new SolidColorBrush(new Windows.UI.Color { A = 0, B = 0, G = 0, R = 0 });
        }

        private void LauncherUpdateInvoker_UpdateEvent(object sender, object e)
        {
        }

        private void MainFrameChangerInvoker_WindowFrameEvent(object sender, object e)
        {
        }

        public void SetWindowSize(IntPtr hwnd, int width = 1028, int height = 634, int x = 0, int y = 0)
        {
        }

        public static void SetInitialDragArea()
        {
        }

        public static void SetDragArea(RectInt32[] area)
        {
        }

        private static List<RectInt32[]> titleBarDragQueue = new List<RectInt32[]>();

        private static async void RunSetDragAreaQueue()
        {
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}