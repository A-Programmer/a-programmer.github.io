using System;
namespace ISP
{
    public class OnlineOrder : IOrder, IOnlineOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("Product has been added to cart.");
        }

        public void PaypalPayment()
        {
            Console.WriteLine("Redirect user to Paypal gateway ...");
        }
    }
}