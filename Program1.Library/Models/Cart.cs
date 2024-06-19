using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_1.Models
{
    public class Cart
    {
        //data members
        public Item Item { get; set; }
        public int Quantity { get; set; }

        //default constructor
        public Cart(Item item, int quantity)
        {
            Item = item;    
            Quantity = quantity;
        }
    }
}
