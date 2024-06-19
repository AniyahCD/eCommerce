namespace ACD.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); //initalizes window x button and all that

            MainPage = new AppShell();
        }
    }
}
