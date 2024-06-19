using Programming_Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program1.Library.Services
{
    public class CartService
    {
        private InventoryServiceProxy InventoryService;
        private List<Cart> cart;

        public CartService (InventoryServiceProxy inventoryService)
        {
            InventoryService = inventoryService;
            cart = new List<Cart>();
        }

        public void AddToCart()
        {
            Console.WriteLine("Enter Id Of Item To Add To Cart: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = InventoryService.GetId(id);

            Console.WriteLine("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            var cartItem = cart.FirstOrDefault(i => i.Item.Id == id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new Cart(item, quantity));
            }
            InventoryService.UpdateQuantity(id, item.Quantity - quantity);
        }

        public void RemoveFromCart()
        {
            Console.WriteLine("Enter Id Of Item To Remove From Cart: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = InventoryService.GetId(id);

            var cartItem = cart.FirstOrDefault(i => i.Item.Id == id);
            if (cartItem != null)
            {
                InventoryService.UpdateQuantity(id, cartItem.Item.Quantity + cartItem.Quantity);
                cart.Remove(cartItem);
            }
        }

        public void ViewCart()
        {
            decimal subTotal = 0;
            foreach (var cartItem in cart)
            {
                var item = cartItem.Item;
                Console.WriteLine($"[{item.Id}] {item.Name} - {item.Description} - ${item.Price} - {cartItem.Quantity} - ${item.Price * cartItem.Quantity}");
                subTotal = cartItem.Quantity * item.Price;
            }
            Console.WriteLine($"Subtotal: $ {subTotal}");
            Console.WriteLine($"Tax: $ {subTotal * 0.07M}");
            Console.WriteLine($"Total: $ {subTotal * 1.07M}");
        }
    }
}
