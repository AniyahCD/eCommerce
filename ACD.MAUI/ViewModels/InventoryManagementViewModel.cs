using Program1.Library.Services;
using Programming_Assignment_1.Models;

namespace ACD.MAUI.ViewModels
{
    public class InventoryManagementViewModel
    {

        public List<ItemViewModel> Items
        {
            get
            {
                return InventoryServiceProxy.Current?.Items?.Select(c=> new ItemViewModel(c)).ToList() ?? new List<ItemViewModel>();
            }

        }

        public ItemViewModel SelectedItem { get; set; }
        public InventoryManagementViewModel()
        {

        }

        public void AddItem()
        {
            if (SelectedItem.item == null)
            {
                return;
            }
            InventoryServiceProxy.Current.AddOrUpdate(SelectedItem.item);
        }
    }
}
