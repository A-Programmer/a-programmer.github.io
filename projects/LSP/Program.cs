using System;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin adminUser = new Admin
            {
                Name = "Kamran Sadin",
                Role = "Admin"
            };

            Customer customerUser = new Customer
            {
                Name = "John Doe",
                SubscriptionType = 1
            };

            Console.WriteLine($"User name: {adminUser.Name}, Role: {adminUser.Role}");
            Console.WriteLine();

            Console.WriteLine($"User name: {customerUser.Name}, Subscription Type: {customerUser.SubscriptionType}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
