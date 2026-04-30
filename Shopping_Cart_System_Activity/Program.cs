using System;

namespace ShoppingCartSystemActivity
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                // PART 2: ADDED CATEGORY FIELD

                new Product(1, "Resident Evil: Requiem", 3000, 20, "Survival Horror"),
                new Product(2, "Last of Us 2 Remastered", 2000, 10, "Action-Adventure"),
                new Product(3, "Borderlands 4", 1200, 10, "First-Person"),
                new Product(4, "NBA 2K26", 3000, 15, "Sports Simulation"),
                new Product(5, "Tekken 8", 2500, 10, "3D Fighting Game"),
            };

            CartItem[] cart = new CartItem[5];
            int cartCount = 0;

            // PART 2: ORDER HISTORY STORAGE

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

                if (choice == "1")
                {
                    for (int i = 0; i < products.Length; i++)

                    products[i].DisplayProduct(i + 1);

                    Console.WriteLine("Select Product: ");
                    if (!int.TryParse(Console.ReadLine(), out int p) || p < 1 || p > products.Length) continue;

                    Product selected = products[p - 1];
                    if (selected.RemainingStock == 0) continue;

                    Console.WriteLine("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int q) || q <= 0) continue;

                    if(!selected.HasEnoughStock(q)) continue;

                    bool found = false;
                    for (int i = 0; i < cartCount; i++)
                    {
                        if (cart[i].ProductName == selected.Name)
                        {
                            cart[i].Quantity += q;
                            cart[i].Subtotal += selected.GetItemTotal(q);
                            found = true;
                        }
                    }

                    if (!found && cartCount < cart.Length)
                    {
                        cart[cartCount++] = new CartItem
                        {
                            Quantity = q,
                            Subtotal = selected.GetItemTotal(q)
                        };
                    }

                    selected.DeductStock(q);

                    // PART 2: STRICT Y/N VALIDATION

                    if (!AskYN("Add another item? (Y/N): "))
                    {
                        break;
                    } 
                    
                    // PART 2: PRODUCT SEARCH FEATURE

                    else if (choice == "2")
                    {
                        Console.WriteLine("Search: ");
                        string key = Console.ReadLine().ToLower();

                        for (int i = 0; i < products.Length; i++)
                        if (products[i].Name.ToLower().Contains(key))
                        products[i].DisplayProduct(i + 1);

                        Console.ReadLine();
                    }
                    
                    // PART 2: CATEGORY FILTERING FEATURE

                    else if (choice == "3")
                    {
                        Console.WriteLine("Category: ");
                        string cat = Console.ReadLine().ToLower();

                        for (int i = 0; i < products.Length; i++)
                        if (products[i].Name.ToLower() == cat)
                        products[i].DisplayProduct(i + 1);

                        Console.ReadLine();
                    }

                }
            }

            
        }
    }
}