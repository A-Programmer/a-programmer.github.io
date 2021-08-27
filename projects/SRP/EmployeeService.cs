
using System.Threading.Tasks;

namespace SRP
{
    public class EmployeeService
    {
        public async Task Register(Employee employee)
        {
            StaticData.Employees.Add(employee);

            //Email
            INotification emailNotification = new EmailNotification();
            await emailNotification.NotifyAsync(employee.Email, "Registration", "Congratulation! You have been successfully registered.");

            //Sms
            INotification smsNotification = new SmsNotification();
            await smsNotification.NotifyAsync(employee.Mobile, "", "Congratulation! You have been successfully registered.");
        }
    }
}