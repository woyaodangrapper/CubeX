namespace Welcome
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RequestedTheme = ApplicationTheme.Dark;
            new MainWindow().InitializeWindow();
        }
    }
}