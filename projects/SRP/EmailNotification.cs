using System;
using System.Threading.Tasks;

namespace SRP
{
    public class EmailNotification: INotification
    {
        public async Task NotifyAsync(string receiver, string subject, string message)
        {
            // Codes ..
            Console.WriteLine("Email has been sent");
        }
    }
}