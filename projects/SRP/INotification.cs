using System.Threading.Tasks;

namespace SRP
{
    public interface INotification
    {
        Task NotifyAsync(string receiver, string subject, string message);
    }
}