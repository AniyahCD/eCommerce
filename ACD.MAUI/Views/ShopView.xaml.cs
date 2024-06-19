namespace ACD.MAUI.Views;
using Program1.Library.Services;
using Programming_Assignment_1.Models;
using ACD.MAUI.ViewModels;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
        BindingContext = new InventoryManagementViewModel();
    }

    private void ShopBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}