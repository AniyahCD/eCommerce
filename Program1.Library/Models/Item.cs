using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Programming_Assignment_1.Models
{
    public class Item
    {
        //data members
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //default constructor
        public Item()
        {

        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description} - ${Price} - {Quantity}";
        }
    }
}
