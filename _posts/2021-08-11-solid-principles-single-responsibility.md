---
layout: post
title:  "Solid Principles, SRP or Single Responsibility Principle"
date:   2021-08-11 19:55:00 +0430
categories: solid single-responsibility-principle
---
## SOLID Principles
`In Object Oriented Programming there are five design principle called SOLID that helps to keep codes clean and more understandable, flexible and maintainable.`  
In this post i am going to explain first principle called `Single Responsibility Principle (SRP)`.  

1. ### [__*SRP - Single Responsibility Principle*__](https://a-programmer.github.io/solid/single-responsibility-principle/2021/08/11/solid-principles-single-responsibility.html) current
2. [OCP - Open Closed Principle](https://a-programmer.github.io/solid/open-closed-principle/2021/08/12/solid-principles-open-closed-principle.html)
3. [LSP - Liskov Substitution Principle](https://a-programmer.github.io/solid/liskov-substitution-principle/2021/08/13/solid-principles-liskov-substitution-principle.html)
4. [ISP - Interface Segregation Principle](https://a-programmer.github.io/solid/interface-segregation-principle/2021/08/13/solid-principles-interface-segregation-principle-isp.html)
5. [DIP - Dependency Inversion Principle](https://a-programmer.github.io/solid/dependency-inversion-principle/2021/08/14/solid-principles-dependency-inversion-principle-dip.html)


# Single Responsibility Principle
`A class should have only one reason to change.`  
It means a class should not have multiple responsibilities and single responsibility should not be spread across multiple classes or mixed with other responsibilities.  

### Explain more
Let's say that according to this principle a module or class should have a small piece of responsibility in the application. Or as you read, a class or module should have one reason to change.  
And the other benefit is modules, components and classes that have only one responsibility are easier to explain, understand and implement.  
Let's say if you have a problem in the future you know exactly wich class or module should fix, so this reduces number of bugs.   
## Example:
Jack is a programmer and his manager asks for adding a feature called `Employee Management System` wich it has some responsibilities such as user registration and sending email notification after registration, Good, Jack decides to create a class called `EmployeeService` like above (for the sake of simplicity he uses local storage to store data in a class called `StaticData`):  
```
public class EmployeeService
{
    public string FirstName {get; set;}
    public string LastName {get; set;}

    public void Register(EmployeeService employee)
    {
        StaticData.Employees.Add(employee);
    }
}

public class StaticData
{
    public static List<EmployeeService> Employees {get; set;} = new List<EmployeeService>();
}
```
As you can see there are some problems, the main problem is `EmployeeService` is class for employee's functionality not an entity model!  
To keep simple we use console application for UI interaction.
```
class Program
{
    static void Main(string[] args)
    {
        EmployeeService employeeService = new EmployeeService
        {
            FirstName = "Kamran",
            LastName = "Sadin"
        };
        employeeService.Register(employeeService);
        Console.ReadKey();
    }
}
```
As you remember we needed to send email after registration has been completed, so we need to store user email address and a method to send email.  
Here there are two requirements, one is adding new field and another is impacting the functionality. And you can see we have two different type of reason to change single class! So it violates the `Single Responsibility Principle (SRP)`.  
### What is solution?
Let's make some changes in structure, First create separate class for Employee:
```
public class Employee
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
}
```
We need to change `StaticData` class:
```
public class StaticData
{
    public static List<Employee> Employees {get; set;} = new List<Employee>();
}
```
And `EmployeeService` class will look like this:
```
public class EmployeeService
{
    public void Register(Employee employee)
    {
        StaticData.Employees.Add(employee);
    }
}
```
Can you remember second requirement? Sending email after registration, It's a functionality for employees and must be in `EmployeeService`, so let's add it:

```
public class EmployeeService
{
    public async Task Register(EmployeeService employee)
    {
        StaticData.Employees.Add(employee);
        await SendEmailAsync(employee.Email, "Registration Email", "Congratulation! You have been successfully registered.")
    }

    private async Task SendEmailAsync(string email, string subject, string message)
    {
        // Codes ...
    }
}
```
At the end our main method in UI project changes to this:
```
class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee
        {
            FirstName = "Kamran",
            LastName = "Sadin",
            Email = "MrSadin@Gmail.Com"
        };

        EmployeeService employeeService = new EmployeeService();
        employeeService.Register(employee).Wait();
        Console.ReadKey();
    }
}
```

Here is a thing, in the future we will decide to add SMS notification to notify user after registration, Now what? We should change `EmployeeService` to add SMS sending functionality? It seems wrong, We can improve `EmployeeService` because it is a class for Employees not notification!  
Here we can add an interface called `INotification` and two classes called `EmailNotification` and `SmsNotification`:
```
public interface INotification
{
    Task Notify(string receiver, string subject, string message);
}

public class EmailNotification : INotification
{
    public async Task Notify(string receiver, string subject, string message)
    {
        // Codes ..
    }
}


public class SmsNotification : INotification
{
    public async Task Notify(string receiver, string subject, string message)
    {
        // Codes ..
    }
}

```
Great!! Now it is right.  
  
Source code is available [here](https://github.com/A-Programmer/a-programmer.github.io/tree/master/projects/SRP)