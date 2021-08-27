---
layout: post
title:  "Abstract class and Interface"
date:   2021-08-10 18:01:00 +0430
categories: c# 
---
# Abstract class and interface
<p>
In this post i am going to talk about abstract class and interface and differences.
</p>
<p>
Abstract classes and interfaces are similare in some ways, but ther are differences.  
</p>

### Short answer
<p>

An abstract class allows you to create functionality that subclasses can implement or override but an interface `only` allows you to `define` functionality, not implement it. And a class can extend only one abstract class but multiple interfaces.

</p> 

## C# abstract class
An abstract class is like an uncompleted class that can be developed in future and it is like an interface with a wide vision. An abstract class can have abstract methods like interfaces that should implement in derived class, furthermore you can have none abstract methods that does not have to implement in derived class and abstract methods can be abstract in subclasses if subclass is defined as abstract. An abstract class can not be instantiated. A derived class can implement or override abstract class. Also an abstract class can have constructors and this is a major difference between abstract class and interface.  
Let me summarize, the abstract class is powerfull than interface that you have ability to decide if you want to let user decide to use the original methods in abstract class or override them or even you can have abstract methods that user can decide how implement them.

## C# interface
An interface is a contract and likes a framework for classes that derived classes should implement all the methods, 
An interface is basically a contract that doesn't have any implementation. An interface can `only` method declarations and wherever needs you can implement them depend on your needs in derived classes. In interface you can not have constructors and fields and can not be instantiated. And don't forget method declared in an interface must be implemented by the class that inherited from interface or let me say `The class that implemet and interface should implement all its members`.  
You can inherit from more than one interface, also with interface you gain more flexibility and reusability in your codes and code can be more maintainable.

## When do you use interface or abstract?
### Use interface:
1. When you need to use multiple inheritance you should use interface becuase in abstract class you can not.  
2. When you need all methods in base class be implemented by derived class.  
3. Remember an interface is a contract that you should implement all methods in derived class and it is like a framework.  
### Use abstract:
1. When in project you face with many changes in the future because with editing abstract class all implementations change.  
2. When you need fields or constructors you need to use abstract classes.  
3. When you don't want to implement all methods in derived class.    

`By using interface you can use behavior from multiple sources in one class`

## Another thing about interfaces, implicit and explicit interface implementations:
Interfaces can be implemented implicitly or explicitly, Let's play with codes, consider you have an interface called `INotification`:       
```
public interface INotification
{
    void Notify();
}
```
Right? this is a notification system that sends email or SMS to user, now you have a calss called `EmailNotification` that implements the `INotification` interface:
```
public class EmailNotification : INotification
{
    public void Notify()
    {
        //Codes to send email
    }
}
```
Nice, in this class you implemented `Notify` method that send an email to user, Now you want to use this class. The first way is create and instance of `EmailNotification` class explicitly and then call `Notify()` method like this:
```
INotification notificationSystem = new EmailNotification();
notificationSystem.Notify();
```
It works fine, Awesome!  
And the other way is to implement `INotification` interface implicitly:
```
public class EmailNotification : INotification
{
    void INotification.Notify()
    {
        //Codes
    }
}
```
Now you can invoice `Notify()` method the same way using a reference to the `INotification` interface. The difference in the two approaches is that when you implement the interface explicitly in your class, you can invoke the method of your interface using a reference to the interface `only`. Therefore you can not do it with this code snippet:
```
EmailNotification emailNotification = new EmailNotification();
emailNotification.Notify();
```
