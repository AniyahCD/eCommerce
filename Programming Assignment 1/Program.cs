using Program1.Library.Services;
using Programming_Assignment_1.Models;

namespace Programming_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var itemSvc = InventoryServiceProxy.Current;
            var cartSvc = new CartService(itemSvc);
            int choice;
            do
            {
                Console.WriteLine("0. Inventory Managment");
                Console.WriteLine("1. Shop");
                Console.WriteLine("2. Quit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        int imChoice, id;
                        do
                        {
                            Console.WriteLine("0. Add Item To Inventory");
                            Console.WriteLine("1. Remove Item From Inventory");
                            Console.WriteLine("2. Update Item In Inventory");
                            Console.WriteLine("3. View Items In Inventory");
                            Console.WriteLine("4. Go Back");
                            imChoice = Convert.ToInt32(Console.ReadLine());
                            switch (imChoice)
                            {
                                case 0:
                                    itemSvc.AddItem();
                                    break;

                                case 1:
                                    Console.WriteLine("Enter Id Of Product To Remove: ");
                                    id = Convert.ToInt32(Console.ReadLine());
                                    itemSvc.Delete(id);
                                    break;

                                case 2:
                                    itemSvc.UpdateItem();
                                    break;

                                case 3:
                                    itemSvc?.Items?.ToList()?.ForEach(Console.WriteLine);
                                    break;

                                case 4:
                                    Console.WriteLine("Going back...");
                                    break;

                                default:
                                    Console.WriteLine("Invalid Choice. Please Enter A Valid Option.");
                                    break;
                            }
                        } while (imChoice != 4);
                        break;

                    case 1:
                        int scChoice;
                        do
                        {
                            Console.WriteLine("0. Add Item To Shopping Cart");
                            Console.WriteLine("1. Remove Item From Shopping Cart");
                            Console.WriteLine("2. Checkout");
                            Console.WriteLine("3. Go Back");
                            scChoice = Convert.ToInt32(Console.ReadLine());

                            switch (scChoice)
                            {
                                case 0:
                                    cartSvc.AddToCart();
                                    break;

                                case 1:
                                    cartSvc.RemoveFromCart();
                                    break;

                                case 2:
                                    cartSvc.ViewCart();
                                    break;

                                case 3:
                                    Console.WriteLine("Going back...");
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                                    break;
                            }
                        } while (scChoice != 3);
                        break;

                    case 2:
                        Console.WriteLine("Goodbye.");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Please Enter A Valid Option.");
                        break;
                }
            } while (choice != 2);
        }
    }
}
