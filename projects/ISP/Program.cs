using System;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineOrder onlineOrder = new OnlineOrder();
            onlineOrder.AddToCart();
            onlineOrder.PaypalPayment();

            Console.WriteLine("-----------");

            OfflineOrder offlineIrder = new OfflineOrder();
            offlineIrder.AddToCart();
        }
    }
}
