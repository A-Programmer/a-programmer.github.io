using System;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee
            {
                FirstName = "Kamran",
                LastName = "Sadin",
                Email = "MrSadin@Gmail.Com",
                Mobile = "+989112794171"
            };

            EmployeeService employeeService = new EmployeeService();
            employeeService.Register(employee).Wait();

            Console.ReadKey();
        }
    }
}
