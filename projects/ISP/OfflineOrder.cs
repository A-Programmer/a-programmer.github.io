using System;
namespace ISP
{
    public class OfflineOrder : IOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("Product has been added to cart.");
        }
    }
}