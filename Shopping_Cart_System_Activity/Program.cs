using System;

namespace Shopping_Cart_System_Quiz
{
    static void Main(string[] args)
    {
        // Created Array of Products (Video Game Products/Items in particular.)
        Product[] products = new Product[]
        {
            new Product(1, "Resident Evil: Requiem", 3500, 20),
            new Product(2, "Last of Us 2 Remastered", 2000, 10),
            new Product(3, "Borderlands 4", 1200, 10),
            new Product(4, "NBA 2K26,", 3000, 15),
            new Product(5, "Tekken 8", 2500, 10),
        };

        // Created Cart Array for Maximum of 20 Video Game Products/Items only.)
        CartItem[] cart = new CartItem[20];
        int cartCount = 0; // This helps keep track of items/products in cart.

        while(true) // This loop continues not until the user stops shopping.
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to Video Game Shop! ===\n");

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct(i + 1);
            }

            
        }   
    }
}