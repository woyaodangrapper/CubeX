using Microsoft.UI.Xaml.Controls;
using NewUI.Welcome.Extensions;
using Welcome;

namespace Windows
{
    public sealed partial class Welcome : Page
    {
        private readonly ApplicationWindowInfo _windowDefault = WindowDefaultDependency.Instance;

        public Welcome()
        {
            InitializeComponent();
        }

        public void NextClick(object sender, RoutedEventArgs e)
        {
            _windowDefault.WindowHandle.WindowSize(WindowSize.CurrentWindowSize.WindowBounds.Width, WindowSize.CurrentWindowSize.WindowBounds.Height);
            _windowDefault.RootFrame?.Navigate(typeof(Windows.Pages.StartupPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}