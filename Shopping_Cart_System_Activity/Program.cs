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

            // Ask the user to choose product/s available.
            Console.WriteLine("Enter product/s that you want to buy: ");
            string input = Console.ReadLine();

            int productIndex;
            
            // Check if the user's input is a valid number or not.
            if (!int.TryParse(input, out productIndex))
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                continue;
            }

            productIndex--; // Adjust because array starts at 0.

            // Check if the product ID is valid or not.
            if (productIndex <0 || productIndex >= products.Length)
            {
                Console.WriteLine("Invalid Product ID!");
                Console.ReadLine();
                continue;
            }

            Product selected = products[productIndex]; // Selected Product

            // Check if product is out of stock.
            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("This particular Video Game Product is out of stock already!");
                Console.ReadLine();
                continue;
            }

            // Ask the user the quantity of games he'd or she'd like to buy.
            Console.WriteLine("Enter the quantity of game/s you'd like to buy: ");
            string qtyInput = Console.ReadLine();

            int qty;

            // Validate quantity input.
            if (!int.TryParse(qtyInput, out qty) || qty <= 0)
            {
                Console.WriteLine("Invalid Quantity!");
                Console.ReadLine();
                continue;
            }

            // Check if there's enough stock to the desired product/s the user wants to buy.
            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("Not Enough Stock Available for this Game already!");
                Console.ReadLine();
                continue;
            }

            // Check if the product/s already exists in cart.
            bool found = false;

            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].ProductName == selected.Name)
                {
                    // Updates existing cart item or product.
                    cart[i].Quantity += qty;
                    cart[i].Subtotal += selected.GetItemTotal(qty);
                    found = true;
                    break;
                }
            }
            // If item or product is not found, then add new item or product to cart.
            if (!found)
            {
                // Check if cart is full already.
                if (cartCount >= cart.Length)
                {
                    Console.WriteLine("Cart is full already!");
                    Console.ReadLine();
                    continue;
                }
                
                // Add new item or product to cart
                cart[cartCount] = new CartItem
                {
                    ProductName = selected.Name,
                    Quantity = qty,
                    Subtotal = selected.GetItemTotal(qty)
                };

                cartCount++; // Increase cart count.
            }
            // Deduct Stock Update after adding to cart.
            selected.DeductStock(qty);
            Console.WriteLine("Video Game Product added to cart!");

            // Ask if the user wants to continue or not.
            Console.WriteLine("\nAdd more product to your cart? (Y/N); ");
            string again = Console.ReadLine().ToUpper();

            if (again != "Y")
                break;       
        }

        Console.Clear();
        Console.WriteLine("=== RECEIPT ===\n");

        double grandTotal = 0;
        for (int i = 0; i < cartCount; i++)
        {
            Console.WriteLine($"{cart[i].ProductName}x{cart[i].Quantity} = {cart[i].Subtotal}");
            grandTotal += cart[i].Subtotal;
        }

        Console.WriteLine($"\nGrand Total of your purchase is: {grandTotal}");

        double discount = 0;          
    }   
}