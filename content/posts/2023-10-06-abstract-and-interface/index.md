---
date: '2026-01-08T10:35:52+03:30'
draft: false
title: 'Abstract and Interface in C#'
tags: ["abstract", "csharp", "dotnet", "basics", "interface","class","oop",""]
categories: ["csharp"]
description: "An abstract class in C# is a class marked with the abstract keyword that may contain abstract and non-abstract members (methods, properties, events, etc.)."
---

### Definition 

An abstract class in C# is a class marked with the abstract keyword that may contain abstract and non-abstract members (methods, properties, events, etc.).  
An abstract class provides a common structure and behavior for derived classes and allows for partial implementation by providing some method implementations while requiring derived classes to implement others.  
An abstract class is like an uncompleted class that can be developed in the future and it is like an interface with a wide vision. An abstract class can have abstract methods like interfaces that should be implemented in the derived class, furthermore, you can have non-abstract methods that do not have to be implemented in a derived class, and abstract methods can be abstract in subclasses if a subclass is defined as abstract. An abstract class can not be instantiated. A derived class can implement or override an abstract class. Also, an abstract class can have constructors and this is a major difference between an abstract class and an interface. Let me summarize, the abstract class is more powerful than the interface in that you have the ability to decide if you want to let the user decide to use the original methods in the abstract class or override them or even you can have abstract methods that the user can decide how to implement them.

We usually use abstract classes when we want to define a base class with common behavior for a group of related classes or when we want to enforce specific methods to be implemented by derived classes.

### Example 

Let’s see an example of an abstract class and its usage:

    abstract class Shape
    {
        public abstract void Draw(); 
    
        public void Move(int newX, int newY)
        {
            // Some code
        }
    }
    
    class Circle : Shape
    {
        public override void Draw()
        {
            // Implementation for drawing a Circle
        }
    }
    
    class Square : Shape
    {
        public override void Draw()
        {
            // Implementation for drawing a Square
        }
    }
    

### When to use 

1.  When in a project you face many changes in the future because with editing abstract class all implementations change.
2.  When you need fields or constructors you need to use abstract classes.
3.  When you don’t want to implement all methods in the derived class.

Interfaces 
-----------------------------------------

### Definition 

An interface is a contract and like a framework for classes that derived classes should implement all the methods, An interface is basically a contract that doesn’t have any implementation. An interface can only method declarations and wherever needs you can implement them depending on your needs in derived classes. In the interface, you can not have constructors and fields, and can not be instantiated. And don’t forget method declared in an interface must be implemented by the class that is inherited from the interface or let me say The class that implements and interface should implement all its members. You can inherit from more than one interface, also with the interface you gain more flexibility and reusability in your codes and code can be more maintainable.

> By using the interface you can use behavior from multiple sources in one class. {: .prompt-info }

### Example 

Let’s implement our example with the interface:

    interface IDrawable
    {
        void Draw();  // Method signature without implementation
    }
    
    class Circle : IDrawable
    {
        public void Draw()
        {
            // Implementation for drawing a Circle
        }
    }
    
    class Square : IDrawable
    {
        public void Draw()
        {
            // Implementation for drawing a Square
        }
    }
    

### When to use 

1.  When you need to use multiple inheritances you should use interface because in abstract class you can not.
2.  When you need all methods in the base class to be implemented by a derived class.
3.  Remember an interface is a contract that you should implement all methods in the derived class and it is like a framework.

### Implicit and explicit interface implementations: 

Interfaces can be implemented implicitly or explicitly, Let’s play with codes, consider you have an interface called `INotification`:

    public interface INotification
    {
        void Notify();
    }
    

Right? this is a notification system that sends email or SMS to the user, now you have a class called `EmailNotification` that implements the `INotification` interface:

    public class EmailNotification : INotification
    {
        public void Notify()
        {
            //Codes to send email
        }
    }
    

Nice, in this class you implemented `Notify` method that sends an email to the user, Now you want to use this class. The first way is to create an instance of `EmailNotification` class explicitly and then call `Notify()` method like this:

    INotification notificationSystem = new EmailNotification();
    notificationSystem.Notify();
    

It works fine, Awesome!  
The other way is to implement `INotification` interface implicitly:

    public class EmailNotification : INotification
    {
        void INotification.Notify()
        {
            //Codes
        }
    }
    

Now you can invoice `Notify()` method the same way using a reference to the `INotification` interface. The difference between the two approaches is that when you implement the interface explicitly in your class, you can invoke the method of your interface using a reference to the interface `only`. Therefore you can not do it with this code snippet:

    EmailNotification emailNotification = new EmailNotification();
    emailNotification.Notify();
    

Abstract vs. Interface 
----------------------------------------------------------------

Abstract Class

Interface

Method Implementations

Can have method implementations.

Contains only method signatures.

Members

Can have abstract and non-abstract members.

Contains method signatures, properties, events, etc.

Inheritance

Supports single inheritance.

Supports multiple inheritance.

Instantiation

Cannot be instantiated directly.

Cannot be instantiated directly; a class must implement it.

Usage examples 
-------------------------------------------------

### Abstract classes usage 

In a game development scenario, you might have an abstract class GameObject that defines common properties and methods for all game objects (e.g., position, rotation, update behavior). Derived classes like Player and Enemy can extend this abstract class to define specific behaviors.

### Interfaces usage 

Consider a banking application where different classes like SavingsAccount and CheckingAccount need to have audit functionality. You can define an IAuditable interface with methods like LogTransaction and GenerateAuditReport. Both account classes can implement this interface to provide auditing functionality.