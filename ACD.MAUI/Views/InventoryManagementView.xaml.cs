using ACD.MAUI.ViewModels;
using Program1.Library.Services;
using Programming_Assignment_1.Models;

namespace ACD.MAUI.Views;

public partial class InventoryManagementView : ContentPage
{
	public InventoryManagementView()
	{
		InitializeComponent();
        BindingContext = new InventoryManagementViewModel();
	}

    public void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).AddItem();
    }
    private void InvBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}