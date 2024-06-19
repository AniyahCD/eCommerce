using Programming_Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACD.MAUI.ViewModels
{
    public class ItemViewModel
    {
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public Item? item { get; set; }

        public ItemViewModel() 
        {
            item = new Item();
        }

        public ItemViewModel(Item c)
        {
            item = c;
        }

        public string? Display
        {
            get
            {
                return ToString();
            }
        }

    }
}
