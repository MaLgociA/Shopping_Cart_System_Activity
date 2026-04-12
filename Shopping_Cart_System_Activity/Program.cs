using System;
using System.Net.Http.Headers;

namespace Shopping_Cart_System_Quiz
{
    static void Main(string[] args)
    {
        Product[] products = new Product[]
        {
            new Product(1, "Resident Evil: Requiem", 3500, 20),
            new Product(2, "Last of Us 2 Remastered", 2000, 10),
            new Product(3, "Borderlands 4", 1200, 10),
            new Product(4, "NBA 2K26,", 3000, 15),
            new Product(5, "Tekken 8", 2500, 10),
        };
    }
}