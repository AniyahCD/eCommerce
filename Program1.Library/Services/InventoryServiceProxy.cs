using Programming_Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program1.Library.Services
{
    public class InventoryServiceProxy
    {
        private InventoryServiceProxy()
        {
            items = new List<Item> {
                new Item{Name = "Tennis Balls"}, new Item{Name = "Basketballs"}
            };
        }

        private static InventoryServiceProxy? instance;
        private static object instanceLock = new object();
        public static InventoryServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new InventoryServiceProxy();
                    }
                }
                return instance;
            }
        }

        private List<Item>? items;
        public ReadOnlyCollection<Item>? Items
        {
            get
            {
                return items?.AsReadOnly();
            }
        }

        public int LastId
        {
            get
            {
                if (items?.Any() ?? false)
                {
                    return items?.Select(c => c.Id)?.Max() ?? 0;
                }
                return 0;
            }
        }
        public Item GetId(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }
        public Item? AddOrUpdate(Item item)
        {
            if (items == null)
            {
                return null;
            }

            var isAdd = false;

            if (item.Id == 0)
            {
                item.Id = LastId + 1;
                isAdd = true;
            }

            if (isAdd)
            {
                items.Add(item);
            }

            return item;
        }

        public void AddItem()
        {
            var item = new Item();
            Console.WriteLine("Enter Item Name: ");
           item.Name = Console.ReadLine();

            Console.WriteLine("Enter Item Description: ");
            item.Description = Console.ReadLine();

            Console.WriteLine("Enter Item Price: ");
            item.Price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Item Quantity: ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            AddOrUpdate(item);
        }

        public void UpdateItem()
        {
            Console.WriteLine("Enter Id Of Item To Update: ");
            var id = int.Parse(Console.ReadLine());

            var item = items.FirstOrDefault(i => i.Id == id);
            Console.WriteLine("Enter New Item Name: ");
            item.Name = Console.ReadLine();

            Console.WriteLine("Enter new Item Description:: ");
            item.Description = Console.ReadLine();

            Console.WriteLine("Enter new Item Price: ");
            item.Price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Item Quantity: ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            AddOrUpdate(item);
        }

        public void Delete(int id)
        {
            if (items == null)
            {
                return;
            }
            var itemToDelete = items.FirstOrDefault(c => c.Id == id);

            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var item = GetId(id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }
    }
}
