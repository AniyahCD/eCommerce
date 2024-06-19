using ACD.MAUI.ViewModels;
using System.Diagnostics;

namespace ACD.MAUI
{
    public partial class MainPage : ContentPage
    {
        public string Title { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void InvClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Management");
        }

        private void ShopClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Shop");
        }
    }

}
