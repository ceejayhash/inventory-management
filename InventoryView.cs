using System;
using InventoryApp.Services;

namespace InventoryApp.Views
{
    public class InventoryView
    {
        private InventoryService service = new InventoryService();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n==== INVENTORY MENU ====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        service.ResetInventory();
                        Console.WriteLine("Inventory reset successfully!");
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            string[,] products = service.GetInventory();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
            }
        }

        private void UpdateStock()
        {
            ViewInventory();

            Console.Write("Select product number (1-3): ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("Enter new stock quantity: ");
            string newStock = Console.ReadLine();

            service.UpdateStock(index, newStock);

            Console.WriteLine("Stock updated successfully!");
        }
    }
}