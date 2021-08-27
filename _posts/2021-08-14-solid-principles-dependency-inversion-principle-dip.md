---
layout: post
title:  "Solid Principles, DIP Dependency Inversion Principle"
date:   2021-08-14 17:15:00 +0430
categories: solid dependency-inversion-principle
---
## Solid Principles
`In Object Oriented Programming there are five design principle called SOLID that helps to keep codes clean and more understandable, flexible and maintainable.`  
In this post i am going to explain first principle called `Single Responsibility Principle (SRP)`.  

1. [SRP - Single Responsibility Principle](https://a-programmer.github.io/solid/single-responsibility-principle/2021/08/11/solid-principles-single-responsibility.html)
2. [OCP - Open Closed Principle](https://a-programmer.github.io/solid/open-closed-principle/2021/08/12/solid-principles-open-closed-principle.html)
3. [LSP - Liskov Substitution Principle](https://a-programmer.github.io/solid/liskov-substitution-principle/2021/08/13/solid-principles-liskov-substitution-principle.html)
4. [ISP - Interface Segregation Principle](https://a-programmer.github.io/solid/interface-segregation-principle/2021/08/13/solid-principles-interface-segregation-principle-isp.html)
5. ### [__*DIP - Dependency Inversion Principle*__](https://a-programmer.github.io/solid/dependency-inversion-principle/2021/08/14/solid-principles-dependency-inversion-principle-dip.html) Current

# Dependency Inversion Principle (DIP)
DIP says high-level modules should not depend on low-level modules and both should depend on abstractions (interfaces), and abstractions should not depend on details but details should depend on abstractions.  
DIP decouples `high` and `low-level` components and instead connects both to abstractions. High and low-level components can benefit from each other but changes in one should not force you change another. In fact advantage of this principle is that decoupled programs require less work to change.  
`If you minimize dependencies, changes will be more localized and require less work to find all affected components.`  
Also it says that `the abstraction should not affected if details are changes.`  
In the below we have a `Customer` class and `FileLogger` class that as you can see `Customer` class depends on `FileLogger` class because if we want to change logger we should modify `Customer` class:  
```
public class Customer
{
    privare FileLogger logger = new FileLogger();
    public virtual void Add()
    {
        try
        {
            //Add customer to database
        }
        catch(Exception ex)
        {
            logger.Handle(ex.Message);
        }
    }
}
```
Also there is another problem that we are using `FileLogger` instead of interface.  
Let's make this right:
```
public interface ILogger
{
    void Handle(string message);
}

public class FileLogger : ILogger
{
    public void Handle(string message)
    {
        // Write error in a file
    }
}

public class DatabaseLogger : ILogger
{
    public voic Handle(string message)
    {
        // Log message in database
    }
}

public class EmailLogger : ILogger
{
    public void Handle(string message)
    {
        //Email log
    }
}
```
Now we created an interface and then one class for each logger type, Ok now we can inject `ILogger` in `Customer` class:  
```
public class Customer
{
    privare ILogger _logger;
    public Customer(ILogger logger)
    {
        _logger = logger;
    }

    public virtual void Add()
    {
        try
        {
            // ...
        }
        catch(Exception ex)
        {
            _logger.Handle(ex.Message);
        }
    }
}
```