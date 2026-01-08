---
date: '2023-10-18T11:09:23+03:30'
draft: false
title: 'A Guide to Event Handling in C#'
tags: ["abstract", "csharp", "dotnet", "basics", "event","events", "event_handler","principals","oop"]
categories: ["csharp"]
description: "Events provide a mechanism for communication between different parts of your code, allowing one component to notify others when a specific action or condition occurs."
---
> Events provide a mechanism for communication between different parts of your code, allowing one component to notify others when a specific action or condition occurs. {: .prompt-tip }

Events are a fundamental aspect of C# programming, playing a crucial role in building responsive and interactive applications. They provide a mechanism for communication between different parts of your code, allowing one component to notify others when a specific action or condition occurs. Whether you’re a beginner or an experienced C# developer, understanding events is essential for effective software development.

In this comprehensive guide, we’ll explore C# events from the ground up, covering everything from the basic syntax to advanced usage and real-world examples. By the end of this article, you’ll have a solid grasp of how events work and how to leverage them in your C# projects.

Stay tuned as we embark on this journey to demystify C# events and equip you with the knowledge and skills to use them effectively in your coding adventures. Let’s start with the fundamentals in the next section.

Understanding C# Events 
------------------------------------------------------------------

Before delving into the world of C# events, let’s begin with the basics. What exactly are events, and why are they essential in C# programming?

### What Are Events? 

Events are a way to facilitate communication between different parts of your C# code. They enable one component (the publisher) to notify other components (subscribers) when a specific action or condition occurs. This notification allows subscribers to respond to events and perform specific tasks, making your code more dynamic and interactive.

Basic Event Structure 
---------------------------------------------------------------

Events in C# have a straightforward structure. They consist of:

1.  **Event Publisher**: This is the object that generates the event. It provides a mechanism for subscribers to register their interest in the event.
    
2.  **Event Subscribers**: These are the objects or methods that want to be notified when the event occurs.
    
3.  **Event Handler**: An event handler is a method that gets executed when the event occurs. It’s responsible for responding to the event.
    

Basic Syntax 
---------------------------------------------

Here’s a simple example of the basic syntax for creating an event in C#:

    public class EventPublisher
    {
        // Declare an event using the 'event' keyword.
        public event EventHandler MyEvent;
    
        // Method to trigger the event.
        public void RaiseEvent()
        {
            // Check if there are subscribers before raising the event.
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }
    

In the code above, we’ve declared an event named `MyEvent` within the `EventPublisher` class. The `RaiseEvent` method is used to trigger this event.

Example 
-----------------------------------

Let’s illustrate the concept with a simple example. In this example, we have an event named `ButtonClicked` that gets raised when a button is clicked in a Windows Forms application.

    public class ButtonClickHandler
    {
        public void HandleButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("Button was clicked!");
        }
    }
    
    // Create an instance of the event publisher.
    EventPublisher button = new EventPublisher();
    
    // Create an instance of the event subscriber.
    ButtonClickHandler subscriber = new ButtonClickHandler();
    
    // Subscribe to the event.
    button.MyEvent += subscriber.HandleButtonClick;
    
    // Simulate a button click.
    button.RaiseEvent();
    

In the example above, when the button’s `RaiseEvent` method is called, the event is raised, and the `HandleButtonClick` method of the `ButtonClickHandler` subscriber is executed.

It’s a really simpke sample, isn’t it? I mean it doesn’t feel real, so let’s have a real example.  
**Here is the story**: We are working on a online store web application, it has product and each project has a name and a price, like this:

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    

I am not going to talk about the Principles and Standards, so let’s keep it simple, just let’s make it a bit better by encapsulation:

    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    
        public string Name { get; private set; }
        public decimal Price {get; private set; }
    
        public void ChangePrice(decimal price) => Price = price;
        public void ChangeName(string name) => Name = name;
    }
    

Now it looks better.  
So, any product price might be changed, right? And we may need to notify some services about this price change, like sending price updates to users, updating shopping carts, etc. Of course, we can do the update by calling an API endpoint, calling a function, or calling service but the problem is, today we need to send an email and we can all the API to send the update email, tomorrow we may need to update shopping cart, so we need to add another code to call the UpdateShoppingCarts function, and then we may need to send a notification for online users, so we need to do other codings and change the UpdatePrice function to add these codes!  
Wouldn’t it be better if we could just raise an event while we don’t care who is listening to this event and put the responsibility of how to treat this event on the head of the one who is listening to this event? I mean can you remember the SRP (Single Responsibility Principle)?  
The product shouldn’t be responsible for doing the actual actions of other services, it should just notify them. Also, OCP (Open/Closed Principle), SoC (Separation of Concern), and some other principles that I will mention a bit later. By this explanation, let’s do some coding:

    namespace EventsProject;
    
    public class Product
    {
      public Product(string name, decimal price)
      {
        Price = price;
        Name = name;
      }
    
      public event EventHandler<PriceChangedEventArgs> PriceChanged;
    
      protected void OnPriceChanged(PriceChangedEventArgs e)
      {
        PriceChanged?.Invoke(this, e);
      }
    
      public string Name { get; private set; }
      public decimal Price { get; private set; }
    
      public void ChangeName(string name) => Name = name;
    
      public void ChangePrice(decimal newPrice)
      {
        decimal oldPrice = Price;
        Price = newPrice;
        OnPriceChanged(new PriceChangedEventArgs(oldPrice, Price));
      }
    }
    
    public class PriceChangedEventArgs : EventArgs
    {
      public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
      {
        OldPrice = oldPrice;
        NewPrice = newPrice;
      }
    
      public decimal OldPrice { get; private set; }
      public decimal NewPrice { get; private set; }
    }
    

Now the price Event Change is rasing and we don’t care who is listening to this event. For simplicity, let’s listen to the event in our Main method:

    public static class Program
    {
      public static void Main(string[] args)
      {
        Product monitor = new("LG", 500);
    
        monitor.PriceChanged += Product_PriceChanged;
    
        monitor.ChangePrice(450);
    
        void Product_PriceChanged(object sender, PriceChangedEventArgs e)
        {
          Console.WriteLine($"{((Product)sender).Name} price has been changed to {e.NewPrice}");
        }
      }
    }
    

For practice, you can add another event for product name update.

Now that you’ve got a taste of the basics, we’ll move on to the next post, “Beginner’s Guide,” where we’ll explore event handlers and delegates in more detail.

### You can follow me on the LinkedIn, YouTube, Telegram Group to discuss, and directly send me email. 

*   [Telegram Group](https://t.me/sadinco_csharp)
*   [LinkedIn](https://linkedin.com/in/MrSadin)
*   [Blog](https://sadin.dev)
*   [YouTube](https://youtube.com/c/EnKamran)