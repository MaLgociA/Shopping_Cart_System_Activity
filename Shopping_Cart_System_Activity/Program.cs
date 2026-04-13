using System;
using System.Net.Http.Headers;

namespace Shopping_Cart_System_Quiz
{
    static void Main(string[] args)
    {
        // Created Array of Products (Video Game Products/Items in particular.)
        Product[] products = new Product[]
        {
            new Product(1, "Resident Evil: Requiem", 3000, 20),
            new Product(2, "Last of Us 2 Remastered", 2000, 10),
            new Product(3, "Borderlands 4", 1200, 10),
            new Product(4, "NBA 2K26", 3000, 15),
            new Product(5, "Tekken 8", 2500, 10),
        };

        // Created Cart Array for Maximum of 20 Video Game Products/Items only.)
        CartItem[] cart = new CartItem[20];
        int cartCount = 0; // This helps keep track of items/products in cart.

        while(true) // This loop continues not until the user stops shopping.
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to Video Game Shop! ===\n");

            // To display all products listed.
            for (int i = 0; i < products.Length; i++) // 
            {
                products[i].DisplayProduct(i + 1);
            }
            
            Console.WriteLine("Enter product/s that you want to buy: ");
            string input = Console.ReadLine();

            int productIndex;

            if (!int.TryParse(input, out productIndex))
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                continue;
            }

            productIndex--;

            if (productIndex <0 || productIndex >= products.Length)
            {
                Console.WriteLine("Invalid Product ID!");
                Console.ReadLine();
                continue;
            }

            Product selected = products[productIndex];

            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("This particular Video Game Product is out of stock already!");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine("Enter the quantity of game/s you'd like to buy: ");
            string qtyInput = Console.ReadLine();

            int qty;

            if (!int.TryParse(qtyInput, out qty) || qty <= 0)
            {
                Console.WriteLine("Invalid Quantity!");
                Console.ReadLine();
                continue;
            }

            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("Not Enough Stock Available for this Game already!");
                Console.ReadLine();
                continue;
            }

            bool found = false;

            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].ProductName == selected.Name)
                {
                    cart[i].Quantity += qty;
                    cart[i].Subtotal += selected.GetItemTotal(qty);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                if (cartCount >= cart.Length)
                {
                    Console.WriteLine("Cart is full already!");
                    Console.ReadLine();
                    continue;
                }
            }
        }   
    }
}