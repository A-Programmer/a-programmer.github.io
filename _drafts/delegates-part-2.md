---
layout: post
title: Delegates Part 2
description: The second post of the Delegates series, I am here to explain delegates in a very simple way.
image:
category:
- C#
- C# Developer Roadmap
tags:
- csharp
- delegate
- c# developer roadmap
- 1000daysofcsharp
- day21
---



## Target methods

As you remember, we agreed that a delegate can point to a method, right? In simple words, it means that we can have a variable that can hold a method in it and then we can call that method by calling this variable.
We have local, static, and instance methods in C#, so the delegate can point to which of them? All! A delegate's target method can be a local, static, or instance method.

```csharp
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
```

## Multicasting

One of the interesting parts of delegates is multicasting, a regular variable can hold the data, right? an `int` variable can hold only one number and if you try to assign another number, it will be replaced by the new number. In delegates, we can assign multiple methods to one delegate instance by using + and += operators.

```csharp
Transformer transformer = Square;
transformer += Cube;
```

Invoking transformer will invoke both Square and Cube in the order in which they are added.  
How about removing a method from a delegate? To remove a method from a delegate you can use - and -= operators.

```csharp
transformer -= Square;
```

>Delegates are immutable, so when you call -= or +=, you are creating a new delegate instance and assigning it to the existing variable.
{: .prompt-tip }

How about if we assign multiple methods with nonvoid return type to a delegate? Which result will be returned? The caller receives the return value from the last method to be invoked. This doesn't mean that the other methods are not going to be called, they are called but the return values will be discarded.
It doesn't make sense to have multicast delegate with multiple methods that return value unless some specific cases, so don't worry about this part, you won't need this much.

Let's see an example:  

```csharp
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
```

On line 3 we create our delegate (contract or rule) and on lines 14, 15, and 16 we create a multicast delegate instance to call both ConsoleLogger and FileLogger methods. After running the application, you will see the `My Log Message` printed on the screen and a file created in your application root called `Log.txt` which contains `My Log Message`.

## Generic Delegate Types

I want to make this topic more interesting, Let's continue with the Transformer example, we want to calculate the Square and Cube of the given number as following:

```csharp
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
```

It would be better if we could cover any type of numbers with one delegate, wouldn't it? I mean, currently, the delegate is only compatible with methods that return `int` and accpect an `int` as parameter, right? If you write the Cube method with `double` return type and `double` parameter, you have to create another delegate with `double` return and parameter type, right?  
Can you remember Generics in C# that I have published a post about them? We can have same solution here.  

The syntax of Generic Delegate Types is as the following:

```csharp
public delegate T MethodName<T>(T arg);
```

Now, let's update our Transformer delegate:

```csharp
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
```

Awesome!

In the next post I will talk about two pre-defined and specific types of delegates called `Func` and `Action`.