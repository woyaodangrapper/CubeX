namespace Welcome
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new MainWindow()
                .InitializeWindowProperties();
        }
    }
}