---
date: '2023-10-04T10:04:40+03:30'
draft: false
title: 'Delegates Part 2'
description: "This post is just to get familiar with Delegates in C#, in the next posts I will talk about delegates in advance. Part 2"
tags: ["delegates", "csharp", "dotnet", "basics"]
categories: ["csharp"]
---

*   [**Delegates Part 1**](/posts/2023-10-01-delegates-part-1-plugin-methods-with-delegates/)
*   [**Delegates Part 2**](/posts/2023-10-04-delegates-part-2/)

Prerequisits 
---------------------------------------------

You want to read the second part of Delegates, right?

*   The first thing that you need is to read the [previous part (Part 1)](/posts/delegates-part-1-plugin-methods-with-delegates/).
*   **The next thing is putting a smile please put a smile on your face then start to read the article**.

Target methods 
-------------------------------------------------

As you remember, we agreed that a delegate can point to a method, right? In simple words, it means that we can have a variable that can hold a method in it and then we can call that method by calling this variable.  
We have local, static, and instance methods in C#, so the delegate can point to which of them? All! A delegate’s target method can be a local, static, or instance method.

    // Static target method
    Transformer transformer = Test.Square;
    Console.WriteLine(transformer(10)); // 100
    
    class Test
    {
        public static int Square(int x) => x * x;
    }
    delegate int Transformer(int x);
    
    // Instance target method
    Test test = new();
    Transformer transformer = test.Square;
    Console.WriteLine(transformer(10)); // 100
    
    class Test
    {
        public int Square(int x) => x * x;
    }
    delegate int Transformer(int x);
    

Multicasting 
---------------------------------------------

One of the interesting parts of delegates is multicasting, a regular variable can hold the data, right? an `int` variable can hold only one number; if you try to assign another number, it will be replaced by the new number. We can assign multiple methods to one delegate instance by using + and += operators in delegates.

    Transformer transformer = Square;
    transformer += Cube;
    

Invoking transformer will invoke both Square and Cube in the order in which they are added.  
How about removing a method from a delegate? To remove a method from a delegate you can use - and -= operators.

    transformer -= Square;
    

> Delegates are immutable, so when you call -= or +=, you are creating a new delegate instance and assigning it to the existing variable. {: .prompt-tip }

How about if we assign multiple methods with a nonvoid return type to a delegate? Which result will be returned? The caller receives the return value from the last method to be invoked. This doesn’t mean that the other methods are not going to be called, they are called but the return values will be discarded.

It doesn’t make sense to have multicast delegate with multiple methods that return value unless some specific cases, so don’t worry about this part, you won’t need this much.

Let’s see an example:

    class Program
    {
        delegate void Logger(string message);
    
        class LogUtilities
        {
            public static void Log(Logger logger, string message)
            {
                logger(message);
            }
        }
        public static void Main(string[] args)
        {
            Logger logger = ConsoleLogger;
            logger += FileLogger;
            LogUtilities.Log(logger, "My Log Message");
    
            void ConsoleLogger(string message) => Console.WriteLine(message);
            void FileLogger(string message) => System.IO.File.WriteAllText("Log.txt", message);
        }
    }
    

On line 3 we create our delegate (contract or rule) and on lines 14, 15, and 16 we create a multicast delegate instance to call both ConsoleLogger and FileLogger methods. After running the application, you will see the `My Log Message` printed on the screen and a file created in your application root called `Log.txt` which contains `My Log Message`.

Generic Delegate Types 
-----------------------------------------------------------------

I want to make this topic more interesting, Let’s continue with the Transformer example, we want to calculate the Square and Cube of the given number as follows:

    delegate int Transformer(int x);
    
    public static void Main(string[] args)
    {
        Transformer transformer = Square;
        Console.WriteLine(transformer(10)); // 100
    
        transformer = Cube;
        Console.WriteLine(transformer(2)); // 8
    
        static int Square(int a) => a * a;
        static int Cube(int a) => a * a * a;
    
    }
    

It would be better if we could cover any type of numbers with one delegate, wouldn’t it? I mean, currently, the delegate is only compatible with methods that return `int` and expect an `int` as a parameter, right? If you write the Cube method with a `double` return type and a `double` parameter, you have to create another delegate with a `double` return and parameter type, right?

Can you remember Generics in C# that I have published a post about them? We can have the same solution here.

The syntax of Generic Delegate Types is as follows:

    public delegate T MethodName<T>(T arg);
    

Now, let’s update our Transformer delegate:

    delegate T Transformer<T>(T x);
    
    public static void Main(string[] args)
    {
        Transformer<int> intTransformer = Square;
        Console.WriteLine(intTransformer(10)); // 100
    
        Transformer<double> doubleTransformer = Cube;
        Console.WriteLine(doubleTransformer(2.0)); // 8
    
        static int Square(int a) => a * a;
        static double Cube(double a) => a * a * a;
    }
    

Awesome, right?

Func and Action 
---------------------------------------------------

Now you know about the generic delegates and how to create one, by generic delegates you can create delegates with any input and output type. C# has built-in generic delegates, **Func** and **Action**.

### Func 

**Func** is a built-in delegate that that represents a method that takes one or more (up to 16) parameters and returns a value, the return type of `Func` can be any type.

    Func<T1, T2, T3, ..., T16, TResult>
    

`T1` … `T16` are parameters and `TResult` is the return value.

Let’s see it in an example:

    class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => a / b;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var FuncCalculator = new Calculator();
    
            Func<int, int, int> add = FuncCalculator.Add;
            Func<int, int, int> subtract = FuncCalculator.Subtract;
            Func<int, int, int> multiply = FuncCalculator.Multiply;
            Func<int, int, int> divide = FuncCalculator.Divide;
    
            Console.WriteLine($"Addition result: {add(10, 5)}");
            Console.WriteLine($"Subtraction result: {subtract(10, 5)}");
            Console.WriteLine($"Multiplication result: {multiply(10, 5)}");
            Console.WriteLine($"Division result: {divide(10, 5)}");
        }
    }
    
    // Or
    
    Func<int, int, int> add = (a, b) => a + b;
    Func<int, int, int> subtract = (a, b) => a - b;
    Func<int, int, int> multiply = (a, b) => a * b;
    Func<int, int, int> divide = (a, b) => a / b;
    
    Console.WriteLine($"Addition result: {add(10, 5)}");
    Console.WriteLine($"Subtraction result: {subtract(10, 5)}");
    Console.WriteLine($"Multiplication result: {multiply(10, 5)}");
    Console.WriteLine($"Division result: {divide(10, 5)}");
    

Easy, right? That’s what a `Func` is:

> A predefined delegate that represents a method with zero or more (up to 16) input parameters and a return type. {: .prompt-tip }

### Action 

In some cases, we don’t need a return value, or we need a delegate that represents a void-returning method. In that case, we can use another predefined delegate called `Action`. **Action** is a predefined delegate type that represents a method with zero or more (up to 16) parameters that doesn’t return any value.

    Action<int, int> ActionCalculator = (a, b) =>
    {
        Console.WriteLine($"Addition result: {a + b}");
        Console.WriteLine($"Subtraction result: {a - b}");
        Console.WriteLine($"Multiplication result: {a * b}");
        Console.WriteLine($"Division result: {a / b}");
    };
    
    ActionCalculator(10, 5);
    

As you can see, we defined an Action delegate that takes two integer parameters performs some arithmetic operations, and returns nothing.

Tips 
-----------------------------

1.  Use Cases:
    *   Use Func when you want a method that computes a result based on input parameters.
    *   Use Action when you want a method to perform some action without returning any value.
2.  Lambda Expressions:
    *   Lambdas are often used with Func and Action to define methods inline without explicitly writing a named method.
3.  Delegate Composition: You can chain multiple Func or Action delegates together using the += operator, allowing for multiple operations in sequence.

Example of Delegate Composition 
-----------------------------------------------------------------------------------

    Action<string> greetAction = message => Console.WriteLine("Greetings: " + message);
    Action<string> farewellAction = message => Console.WriteLine("Farewell: " + message);
    
    Action<string> combinedAction = greetAction + farewellAction;
    
    combinedAction("John");  // Prints both greetings and farewells for "John"
    

Awesome, right?

Use-Cases 
---------------------------------------

### Func: 

1.  **Function Composition:** Combining multiple functions to create a new function by chaining `Func` delegates.
    
2.  **LINQ (Language Integrated Query):** Utilized in LINQ for projection or transformation operations on collections.
    
3.  **Callback Functions:** Providing a callback function to be executed upon completion of an asynchronous operation.
    
4.  **Mapping:** Converting one type of object to another type using a mapping function.
    
5.  **Error Handling:** Defining functions to handle specific error cases or exceptions.
    
6.  **Lazy Evaluation:** Lazily computing values only when needed, particularly useful for performance optimizations.
    
7.  **Configuration:** Supplying functions to configure components or behaviors of a system.
    

### Action: 

1.  **Event Handling:** Defining actions to be executed when an event is raised.
    
2.  **UI Interaction:** Handling user interface events and defining actions to update UI elements.
    
3.  **Logging:** Logging actions or functions that record events or information for debugging or auditing purposes.
    
4.  **Multithreading:** Specifying actions to be executed in separate threads or asynchronously.
    
5.  **Clean-Up Operations:** Defining actions for cleanup or disposal of resources after a specific task.
    
6.  **Callback Functions:** Providing a callback action to be executed upon completion of an asynchronous operation.
    
7.  **Dependency Injection:** Specifying actions to be taken after resolving dependencies in a dependency injection container.
    

> A problem that you can solve with a delegate, can also be solved with an interface. {: .propmt-info }

If you don’t understand this, I suggest you read the article again, look for more examples, and compare delegates and interfaces. And at the end, try to implement previous examples with an interface.

A delegate design might be a better choice than an interface design if one or more of these conditions are true:

*   The interface defines only a single method.
*   Multicast capability is needed.
*   The subscriber needs to implement the interface multiple times.

Delegate compatibility 
-----------------------------------------------------------------

Delegate types are all incompatible with one another, even if their signature is the same:

    D1 d1 = Method1;
    D2 d2 = d1;  // compile time error
    
    void Method1() { }
    
    delegate void D1() { }
    delegate void D2() { }
    

> The following, however, is permitted: D2 d2 = new D2(d1); {: .prompt-info }

Delegates equality  
---------------------------------------------------------

Delegate instances are considered equal if they have the same method targets:

    D d1 = Method1;
    D d2 = Method1;
    
    Console.WriteLine( d1 == d2);  // True
    
    void Method1() { }
    delegate void D() { }
    

Multicast delegates are considered equal if they reference the same methods in the same order.

There are some other topics about delegates, like Parameter compatibility, return type compatibility, covariant, and contravariant that I won’t go through, and you can search about them or ask Chat GPT for the answer with some examples.

Now we are ready to understand the Events concepts. In the next post, I will talk about events and how knowing delegates helps us to learn about Events faster and easier.

**Well done**! Good job guys, you finished the second part of the delegates, **please put a smile on your face** :-).