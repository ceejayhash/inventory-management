namespace InventoryApp.Services
{
    public class InventoryService
    {
        private string[,] products =
        {
            { "Apples", "Milk", "Bread" },   // Row 0 = Product Names
            { "10", "5", "20" }              // Row 1 = Stock Quantities
        };

        private string[] initialStock;

        public InventoryService()
        {
            // Store original stock values for reset
            initialStock = new string[3];
            for (int i = 0; i < 3; i++)
            {
                initialStock[i] = products[1, i];
            }
        }

        public string[,] GetInventory()
        {
            return products;
        }

        public void UpdateStock(int index, string newStock)
        {
            products[1, index] = newStock;
        }

        public void ResetInventory()
        {
            for (int i = 0; i < 3; i++)
            {
                products[1, i] = initialStock[i];
            }
        }
    }
}