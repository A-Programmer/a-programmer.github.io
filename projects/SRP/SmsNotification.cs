using System;
using System.Threading.Tasks;

namespace SRP
{
    public class SmsNotification : INotification
    {
        public async Task NotifyAsync(string receiver, string subject, string message)
        {
            // Codes ..
            Console.WriteLine("Sms has been sent");
        }
    }
}