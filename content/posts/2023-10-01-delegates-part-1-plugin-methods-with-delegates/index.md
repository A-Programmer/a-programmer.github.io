---
date: '2023-10-01T18:06:09+03:30'
draft: false
title: 'Delegates Part 1 Plugin Methods With Delegates'
description: "This post is just to get familiar with Delegates in C#, in the next posts I will talk about delegates in advance."
tags: ["delegates", "csharp", "dotnet", "basics"]
categories: ["csharp"]
---
[**Delegates Part 1**](/posts/delegates-part-1-plugin-methods-with-delegates/) [**Delegates Part 2**](/posts/delegates-part-2/)

**This post is just to get familiar with Delegates in C#, in the next posts I will talk about delegates in advance.**

What is Delegate 
-----------------------------------------------------

> A delegate is an object that knows how to call a method. {: .prompt-tip }

You know variables in C#, right? A delegate is a reference type variable that holds the reference to a method and the reference can be changed at runtime.  
Delegates are usually used for implementing events and the call-back methods (We will get back to this soon).  
Before getting started, let’s see the syntax of a delegate:

Syntax 
---------------------------------

    delegate int Transformer(int x);
    

‘delegate’ keyword is required, and then the return type must be defined and parameters. The ‘Transformer’ delegate is compatible with any method that has an ‘int’ return type and single `int` parameter, such as:

    int Square(int a)
    {
        return a * a;
    }
    

Or:

    int Square(int a) => a * a;
    

Now, we need to use it, right? To use you should create a variable of `Transformer` and assign a method to it:

    Transformer transformer = Squer;
    

In the above code, we have a delegate instance, to invoke the delegate instance, you should do the same way as a method:

    int result = transformer(3); // returns 9
    

Complete code:

    Transformer transformer = Square;
    int result = transformer(3);
    
    int Square(int a) => a * a;
    
    delegate int Transformer(int x);
    

In simple word, by delegates we define a rule or agreement for special variables that can hold a methods that follow that rule. In our example, we defined a rule called Transformer which says, I can hold any method that returns int and accepts a single int as input. From now on, you can create an instance of me, and point to any method that has the same signature through my instance.

**I could call the Square method everywhere, so why do I need to use delegate!?** By using a delegate, you are decoupling the caller from the target method.

Plug-in methods with Delegates 
---------------------------------------------------------------------------------

A delegate variable is assigned a method at runtime! By using this feature, you can write plug-in methods. Using delegates for plug-in methods in C# is a great way to create a flexible and extensible system where you can dynamically add and use different functionalities without modifying the core code. Let’s create a simple example to demonstrate this concept:

Suppose we’re building a calculator application, and we want to allow users to define custom operations that can be plugged into the calculator. We’ll use a delegate to define the structure of a plug-in method.

    public delegate int CustomOperation(int a, int b);
    

The CustomOperation delegate represents a method that takes two integers and returns an integer. This will be the structure of our plug-in methods.

Now, let’s create our Calculator class:

    public class Calculator
    {
        // Delegate instance to hold the plug-in method
        private CustomOperation customOperation;
    
        // Method to set the custom operation plug-in
        public void SetCustomOperation(CustomOperation operation)
        {
            customOperation = operation;
        }
    
        // Method to perform a calculation using the plug-in operation
        public int PerformCustomOperation(int a, int b)
        {
            if (customOperation != null)
                return customOperation(a, b);
            else
                throw new InvalidOperationException("No custom operation set.");
        }
    }
    

Now, we need to use the Calculator with plug-in method:

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
    
            // Define a custom operation (plug-in)
            CustomOperation customOperation = (a, b) => a * a + b * b;
    
            // Or
            // CustomOperation customOperation = SomeOperation;
            //
            // int SomeOperation(int a, int b)
            // {
            //     return a * a + b * b;
            // }
    
            // Set the custom operation in the calculator
            calculator.SetCustomOperation(customOperation);
    
            // Use the custom operation
            int result = calculator.PerformCustomOperation(3, 4);
            Console.WriteLine("Result of custom operation: " + result); // Output: 25
        }
    }
    

It’s a bit confusing and needs more explanation, isn’t it? That’s why I am here! Let me explain it: Of course, we could create our operation methods like Add, Sum, Multi, Div, etc in the Calculator class, but then we were coupling to the Calculator class methods, which means, that every time we need to add/remove an operation, we should modify the Calculator class, right?  
How about using plug-in method feature in our example? By using this feature, we really decoupled the Calculator class and the caller (Main method), we are defining the operation in the Main method and adding/assigning to the Calculator at runtime, by using this, we can add/remove method to/from the Calculator without modifying the Calculator class.