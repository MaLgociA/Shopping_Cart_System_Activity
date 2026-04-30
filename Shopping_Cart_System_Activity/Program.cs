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
                new Product(5, "Tekken 8", 2500, 10, "3D Fighting"),
            };

            CartItem[] cart = new CartItem[5];
            int cartCount = 0;

            // PART 2: Order history storage
            Order[] orders = new Order[20];
            int orderCount = 0;
            int receiptNo = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== MENU ==========");
                Console.WriteLine("1. VIEW PRODUCTS");
                Console.WriteLine("2. SEARCH PRODUCT");      // PART 2
                Console.WriteLine("3. FILTER BY CATEGORY");   // PART 2
                Console.WriteLine("4. MANAGE CART");
                Console.WriteLine("5. CHECKOUT");            // PART 2
                Console.WriteLine("6. VIEW ORDER HISTORY");   // PART 2
                Console.WriteLine("7. ADD STOCK");            // PART 2
                Console.WriteLine("8. EXIT");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    for (int i = 0; i < products.Length; i++)

                        products[i].DisplayProduct(i + 1);

                    Console.Write("Select product: ");

                    if (!int.TryParse(Console.ReadLine(), out int p) || p < 1 || p > products.Length) continue;

                    Product selected = products[p - 1];

                    if (selected.RemainingStock == 0) continue;

                    Console.Write("Quantity: ");

                    if (!int.TryParse(Console.ReadLine(), out int q) || q <= 0) continue;
                    
                    if (!selected.HasEnoughStock(q)) continue;

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
                            ProductName = selected.Name,
                            Quantity = q,
                            Subtotal = selected.GetItemTotal(q)
                        };
                    }

                    selected.DeductStock(q);

                    // PART 2: STRICT VALID Y/N VALIDATION

                    if (!AskYN("Add another item? (Y/N): ")) continue;
                }

                // PART 2: PRODUCT SEARCH FEATURE

                else if (choice == "2")
                {
                    Console.Write("Search: ");
                    string key = Console.ReadLine().ToLower();

                    for (int i = 0; i < products.Length; i++)
                        if (products[i].Name.ToLower().Contains(key))
                            products[i].DisplayProduct(i + 1);

                    Console.ReadLine();
                }

                // PART 2: CATEGORY FILTERING FEATURE

                else if (choice == "3")
                {
                    Console.Write("Category: ");
                    string cat = Console.ReadLine().ToLower();

                    for (int i = 0; i < products.Length; i++)
                        if (products[i].Category.ToLower() == cat)
                            products[i].DisplayProduct(i + 1);

                    Console.ReadLine();
                }

                // PART 2: CART MANAGEMENT SYSTEM

                else if (choice == "4")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("========== CART ==========");

                        for (int i = 0; i < cartCount; i++)
                            Console.WriteLine($"{i + 1}. {cart[i].ProductName} x {cart[i].Quantity} = {cart[i].Subtotal}");

                        Console.WriteLine("\n1. REMOVE   2. UPDATE   3. CLEAR   4. BACK");
                        string c = Console.ReadLine();

                        // PART 2: REMOVE ITEM + RESTORE STOCK

                        if (c == "1")
                        {
                            Console.Write("Item #: ");
                            if (int.TryParse(Console.ReadLine(), out int r) && r > 0 && r <= cartCount)
                            {
                                RestoreStock(products, cart[r - 1]); // RESTORES STOCK
                                for (int i = r - 1; i < cartCount - 1; i++)
                                    cart[i] = cart[i + 1];
                                cartCount--;
                            }
                        }

                        // PART 2: UPDATE QUANTITY + ADJUST STOCK

                        else if (c == "2")
                        {
                            Console.Write("Item #: ");
                            int.TryParse(Console.ReadLine(), out int u);

                            Console.Write("New Qty: ");
                            int.TryParse(Console.ReadLine(), out int nq);

                            if (u > 0 && u <= cartCount && nq > 0)
                            {
                                CartItem item = cart[u - 1];
                                Product prod = FindProduct(products, item.ProductName);

                                int diff = nq - item.Quantity;

                                if (diff > 0 && !prod.HasEnoughStock(diff)) continue;

                                if (diff > 0) prod.DeductStock(diff);
                                else prod.RemainingStock += -diff;

                                item.Quantity = nq;
                                item.Subtotal = prod.Price * nq;
                            }
                        }

                        // PART 2: CLEAR CART + RESTORE ALL STOCK

                        else if (c == "3")
                        {
                            for (int i = 0; i < cartCount; i++)
                                RestoreStock(products, cart[i]);

                            cartCount = 0;
                        }

                        // PART 2: ENHANCED CHECKOUT

                        else if (c == "4")
                        {
                            double total = 0;
                            for (int i = 0; i < cartCount; i++)
                                total += cart[i].Subtotal;

                            double discount = total >= 5000 ? total * 0.10 : 0;
                            double final = total - discount;

                            // PART 2: PAYMENT VALIDATION LOOP

                            double payment;
                            while (true)
                            {
                                Console.WriteLine($"Final: {final}");
                                Console.Write("Payment: ");

                                if (double.TryParse(Console.ReadLine(), out payment) && payment >= final)
                                    break;
                                Console.WriteLine("Invalid or insufficient payment.");
                            }

                            double change = payment - final;

                            // PART 2: RECEIPT NUMBER + DATE/TIME

                            Console.WriteLine($"\nReceipt#: {receiptNo}");
                            Console.WriteLine($"Date: {DateTime.Now}");

                            for (int i = 0; i < cartCount; i++)

                                Console.WriteLine($"{cart[i].ProductName} x {cart[i].Quantity} = {cart[i].Subtotal}");

                            Console.WriteLine($"Total: {total}");

                            Console.WriteLine($"Discount: {discount}");

                            Console.WriteLine($"Final: {final}");

                            Console.WriteLine($"Payment: {payment}");

                            Console.WriteLine($"Change: {change}");

                            // PART 2: SAVE TO ORDER HISTORY

                            orders[orderCount++] = new Order
                            {
                                ReceiptNo = receiptNo++,
                                FinalTotal = final
                            };
                        }
                    }
                }

                // PART 2: CHECKOUT 

                else if (choice == "5")
                {
                    if (cartCount == 0)
                    {
                        Console.WriteLine("Cart is empty.");
                        Console.ReadLine();
                        continue;
                    }

                    double total = 0;
                    for (int i = 0; i < cartCount; i++)
                        total += cart[i].Subtotal;

                    double discount = total >= 5000 ? total * 0.10 : 0;
                    double final = total - discount;

                    double payment;
                    while (true)
                    {
                        Console.WriteLine($"Final: {final}");
                        Console.Write("Payment: ");
                        if (double.TryParse(Console.ReadLine(), out payment) && payment >= final)
                            break;

                        Console.WriteLine("Invalid or insufficient payment.");
                    }

                    double change = payment - final;

                    Console.WriteLine($"\nReceipt#: {receiptNo}");
                    Console.WriteLine($"Date: {DateTime.Now}");

                    for (int i = 0; i < cartCount; i++)
                        Console.WriteLine($"{cart[i].ProductName} x {cart[i].Quantity} = {cart[i].Subtotal}");

                    Console.WriteLine($"Total: {total}");
                    Console.WriteLine($"Discount: {discount}");
                    Console.WriteLine($"Final: {final}");
                    Console.WriteLine($"Payment: {payment}");
                    Console.WriteLine($"Change: {change}");

                    Console.WriteLine("\nLOW STOCK:");
                    for (int i = 0; i < products.Length; i++)
                        if (products[i].RemainingStock <= 5)
                            Console.WriteLine($"{products[i].Name} - {products[i].RemainingStock}");

                            cartCount = 0;
                            Console.ReadLine();
                                continue;

                    orders[orderCount++] = new Order
                    {
                        ReceiptNo = receiptNo++,
                        FinalTotal = final
                    };

                    cartCount = 0;

                    Console.ReadLine();
                    }
                    


                // PART 2: ORDER HISTORY DISPLAY

                else if (choice == "6")
                {
                    Console.WriteLine("========== HISTORY ==========");

                    for (int i = 0; i < orderCount; i++)

                        Console.WriteLine($"Receipt #{orders[i].ReceiptNo} - {orders[i].FinalTotal}");

                    Console.ReadLine();
                }

                // PART 2: MANUAL RESTOCK (ADDITIONAL FEATURE)

                else if (choice == "7")
                {
                    Console.WriteLine("========== RESTOCK ==========");

                    for (int i = 0; i < products.Length; i++)
                        products[i].DisplayProduct(i + 1);

                    Console.Write("Select product #: ");
                    if (!int.TryParse(Console.ReadLine(), out int p) || p < 1 || p > products.Length)
                        return;

                    Console.Write("Enter quantity to add: ");
                    if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                        return;

                    products[p - 1].RemainingStock += qty;

                    Console.WriteLine("Stock updated successfully!");
                    Console.ReadLine();
                }
                
                else if (choice == "8")
                    break;
            }
        }

        // PART 2: STRICT Y/N VALIDATOR
        static bool AskYN(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string ans = Console.ReadLine().ToUpper();

                if (ans == "Y") return true;
                
                if (ans == "N") return false;
                Console.WriteLine("INVALID INPUT. ENTER Y OR N ONLY!");
            }
        }

        // PART 2: HELPER FOR STOCK RESTORATION

        static Product FindProduct(Product[] products, string name)
        {
            for (int i = 0; i < products.Length; i++)

                if (products[i].Name == name)
                    return products[i];

            return null;
        }

        static void RestoreStock(Product[] products, CartItem item)
        {
            Product p = FindProduct(products, item.ProductName);
            if (p != null) p.RemainingStock += item.Quantity;
        }
    }
}

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    // PART 2: CATEGORY FIELD

    public string Category;

    public Product(int id, string name, double price, int stock, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        RemainingStock = stock;
        Category = category;
    }

    public void DisplayProduct(int number)
    {
        Console.WriteLine($"{number}. {Name} - {Price} - {Category} (Stock: {RemainingStock})");
    }

    public double GetItemTotal(int q) => Price * q;
    public bool HasEnoughStock(int q) => RemainingStock >= q;
    public void DeductStock(int q) => RemainingStock -= q;
}

class CartItem
{
    public string ProductName;
    public int Quantity;
    public double Subtotal;
}

// PART 2: ORDER HISTORY STRUCTURE

class Order
{
    public int ReceiptNo;
    public double FinalTotal;
}