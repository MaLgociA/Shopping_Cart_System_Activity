using System;

namespace ShoppingCartSystemActivity
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                // PART 2: Added Category Field

                new Product(1, "Resident Evil: Requiem", 3000, 20, "Survival Horror"),
                new Product(2, "Last of Us 2 Remastered", 2000, 10, "Action-Adventure"),
                new Product(3, "Borderlands 4", 1200, 10, "First-Person"),
                new Product(4, "NBA 2K26", 3000, 15, "Sports Simulation"),
                new Product(5, "Tekken 8", 2500, 10, "3D Fighting Game"),
            };

            CartItem[] cart = new CartItem[5];
            int cartCount = 0;

            // PART 2: Order History Storage
            Order[] orders = new Order[20];
            int orderCount = 0;
            int receiptNo = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== MENU ==========");
                Console.WriteLine("1. VIEW PRODUCTS");
                Console.WriteLine("2. SEARCH PRODUCT"); // PART 2
                Console.WriteLine("3. FILTER BY CATEGORY"); // PART 2
                Console.WriteLine("4. MANAGE CART"); // PART 2
                Console.WriteLine("5. VIEW ORDER HISTORY"); // PART 2
                Console.WriteLine("6. EXIT");

                string choice = Console.ReadLine();
            }

            
        }
    }
}