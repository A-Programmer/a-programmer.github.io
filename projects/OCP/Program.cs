using System;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            SilverCustomer customer1 = new SilverCustomer
            {
                FirstName = "Kamran",
                LastName = "Sadin",
                CustomerType = 1,
                TotalSales = 2000
            };

            GoldenCustomer customer2 = new GoldenCustomer
            {
                FirstName = "John",
                LastName = "Doe",
                CustomerType = 2,
                TotalSales = 2500
            };

            Console.WriteLine($"FullName : {customer1.FirstName + " " + customer1.LastName}, Discount: {customer1.GetDiscount(customer1).ToString()}");
            Console.WriteLine();
            
            Console.WriteLine($"FullName : {customer2.FirstName + " " + customer2.LastName}, Discount: {customer2.GetDiscount(customer2).ToString()}");
            Console.WriteLine();

            Console.WriteLine("----------------------");

            Rectangle rectangle = new Rectangle
            {
                Width = 100,
                Height = 120
            };

            Circle circle = new Circle
            {
                Radius = 10
            };


            Console.WriteLine($"Rectangle area : {rectangle.Area().ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Circle area : {circle.Area().ToString()}");
            Console.WriteLine();

        }
    }
}
