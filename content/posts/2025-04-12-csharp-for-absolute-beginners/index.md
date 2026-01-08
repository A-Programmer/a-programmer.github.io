---
date: '2025-04-12T11:54:41+03:30'
draft: false
title: 'Learn C# from Scratch: A Complete Course for Absolute Beginners'
tags: ["beginners", "csharp", "dotnet", "basics", "introduction","c_sharp", "csharp","principals","oop"]
categories: ["csharp"]
description: "Ready to start your coding journey? If you’ve never programmed before, this C# course is tailor-made for you."
---

Ready to start your coding journey? If you’ve never programmed before, this C# course is tailor-made for you. Over about six weeks, with 2-3 sessions per week (1-2 hours each), you’ll transform from a total beginner to someone who can write simple, functional programs in C#. C# is a powerful, beginner-friendly language used in games, apps, and more. With plenty of examples and step-by-step guidance, this course will make coding fun and approachable. Let’s dive in!

Module 1: Your First Steps with C# 
---------------------------------------------------------------------------------------

**What’s the Goal?** Understand what programming is, set up your coding tools, and write your first C# program.  
**How Long?** 2 sessions

### Session 1: What Is Programming, and Why C#? 

Programming is like giving your computer a set of instructions to follow, like a recipe for your favorite dish. C# (pronounced “see sharp”) is a language that lets you write those instructions clearly. It’s versatile—think building games with Unity or creating apps for Windows—and it’s great for beginners because it’s structured and forgiving.

In this session, you’ll meet Visual Studio Community, a free program where you’ll write and run your code. Think of it as your coding kitchen, with tools to make programming easier.

**What You’ll Do:**

*   Download Visual Studio Community from Microsoft’s website (it’s free!).
*   Open it and explore the interface. You’ll see:
    *   The **code editor**, where you type your instructions.
    *   The **solution explorer**, which organizes your projects.
    *   The **run button** (a green triangle) to test your programs.

**By the End:** You’ll understand what programming and C# are and have Visual Studio ready to go.

### Session 2: Your First C# Program—“Hello, World!” 

Time to write code! Every programmer starts with a “Hello, World!” program that prints a message to the screen. You’ll learn the basics of a C# program’s structure and some simple rules, like ending lines with semicolons (`;`) and grouping code with curly braces (`{}`).

Here’s what a C# program looks like:

    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
        }
    }
    

Let’s break it down:

*   `using System;` brings in tools like `Console.WriteLine` for printing.
*   `class Program` is like a container for your code.
*   `static void Main()` is where your program starts running.
*   `Console.WriteLine("Hello, World!");` tells the computer to display “Hello, World!”.

**What You’ll Do:**

*   Create a new **Console App** project in Visual Studio.
*   Type the code above and press the run button to see “Hello, World!” appear.
*   Change the message to something personal, like:

    Console.WriteLine("Hi, I’m learning C#!");
    

**By the End:** You’ll have written and run your first program, feeling like a coder already!

Module 2: Storing and Using Data 
------------------------------------------------------------------------------------

**What’s the Goal?** Learn how to store information (like numbers and text) and do things with it.  
**How Long?** 3 sessions

### Session 3: Variables—Your Data Boxes 

Imagine variables as labeled containers for storing information, like a jar labeled “Cookies” holding a number of treats. In C#, you create a variable by saying what type of data it holds and giving it a name. Here are the main types we’ll use:

*   `int` for whole numbers (e.g., 5, -10).
*   `double` for decimals (e.g., 3.14).
*   `string` for text (e.g., “Hello”).
*   `bool` for true/false values.

Here’s an example:

    int age = 25;
    string name = "Emma";
    double height = 5.6;
    bool isStudent = true;
    
    Console.WriteLine(name); // Prints: Emma
    Console.WriteLine(age);  // Prints: 25
    

You _declare_ a variable with its type and name (`int age;`), then _assign_ a value using `=` (`age = 25;`). You can do both at once, as shown above.

**What You’ll Do:**

*   Write a program to declare variables like this:

    string favoriteColor = "Blue";
    int numberOfPets = 2;
    Console.WriteLine("My favorite color is " + favoriteColor);
    Console.WriteLine("I have " + numberOfPets + " pets.");
    

*   Change the values and run it again to see different outputs.

**By the End:** You’ll know how to store and display data using variables.

### Session 4: Doing Math with Numbers 

Programs often need to calculate things, like adding scores or splitting a bill. C# uses operators for math:

*   `+` (add), `-` (subtract), `*` (multiply), `/` (divide), `%` (remainder).
*   Example: `10 % 3` gives 1, because 10 divided by 3 leaves a remainder of 1.

Here’s a program that does some math:

    int apples = 5;
    int oranges = 3;
    int totalFruit = apples + oranges;
    double pricePerApple = 0.5;
    double totalCost = apples * pricePerApple;
    
    Console.WriteLine("Total fruit: " + totalFruit); // Prints: Total fruit: 8
    Console.WriteLine("Total cost: $" + totalCost); // Prints: Total cost: $2.5
    

Math follows PEMDAS (Parentheses, Exponents, Multiplication/Division, Addition/Subtraction), so `2 + 3 * 4` equals 14, not 20, because multiplication comes first.

**What You’ll Do:**

*   Create a program to calculate the area of a rectangle:

    int length = 10;
    int width = 4;
    int area = length * width;
    Console.WriteLine("The area is " + area + " square units.");
    

*   Try dividing numbers to see how `int` (whole numbers) differs from `double` (decimals):

    int a = 7;
    int b = 2;
    Console.WriteLine(a / b); // Prints: 3 (drops the decimal)
    double c = 7.0;
    double d = 2.0;
    Console.WriteLine(c / d); // Prints: 3.5
    

**By the End:** You’ll be comfortable doing math and understanding number types.

### Session 5: Text and Chatting with Users 

Text is everywhere in programs—think names, messages, or labels. A `string` holds text, and you can combine strings using `+` (concatenation). Even better, you can ask users for input with `Console.ReadLine()`, which waits for them to type something.

Here’s an example:

    Console.WriteLine("What’s your name?");
    string userName = Console.ReadLine();
    Console.WriteLine("Nice to meet you, " + userName + "!");
    

If you want to work with numbers from user input, you’ll need to convert the input (which is a `string`) to a number using `int.Parse()`:

    Console.WriteLine("How old are you?");
    string input = Console.ReadLine();
    int age = int.Parse(input);
    Console.WriteLine("In 5 years, you’ll be " + (age + 5) + "!");
    

**What You’ll Do:**

*   Write a program to greet a user and tell them something fun:

    Console.WriteLine("Enter your favorite animal:");
    string animal = Console.ReadLine();
    Console.WriteLine("Cool! I bet a " + animal + " would make a great pet!");
    

*   Create a program that calculates a user’s birth year:

    Console.WriteLine("How old are you?");
    int age = int.Parse(Console.ReadLine());
    int currentYear = 2025; // Update if needed
    int birthYear = currentYear - age;
    Console.WriteLine("You were probably born around " + birthYear + ".");
    

**By the End:** You’ll know how to handle text, combine it with other data, and interact with users.

Module 3: Teaching Your Program to Think 
----------------------------------------------------------------------------------------------------

**What’s the Goal?** Make your programs decide what to do and repeat tasks automatically.  
**How Long?** 3 sessions

### Session 6: Decisions with `if` Statements 

Programs need to make choices, like deciding if a user is allowed to log in. You’ll use `if` statements to check conditions. Conditions are questions that are either `true` or `false`, built with comparison operators:

*   `==` (equals), `!=` (not equals), `<` (less than), `>` (greater than), `<=`, `>=`.

Here’s an example:

    int score = 85;
    if (score >= 90)
    {
        Console.WriteLine("You got an A!");
    }
    else if (score >= 80)
    {
        Console.WriteLine("You got a B!");
    }
    else
    {
        Console.WriteLine("Keep studying!");
    }
    

This code checks `score` and prints a message based on its value. The curly braces `{}` group the code that runs if a condition is true.

**What You’ll Do:**

*   Write a program to check a number’s sign:

    Console.WriteLine("Enter a number:");
    int number = int.Parse(Console.ReadLine());
    if (number > 0)
    {
        Console.WriteLine("Positive!");
    }
    else if (number < 0)
    {
        Console.WriteLine("Negative!");
    }
    else
    {
        Console.WriteLine("Zero!");
    }
    

*   Create a voting eligibility checker:

    Console.WriteLine("Enter your age:");
    int age = int.Parse(Console.ReadLine());
    if (age >= 18)
    {
        Console.WriteLine("You can vote!");
    }
    else
    {
        Console.WriteLine("Not old enough yet.");
    }
    

**By the End:** You’ll be able to make your programs choose what to do based on conditions.

### Session 7: Loops—Repeating Made Easy 

Loops let your program repeat tasks without you rewriting code. A `for` loop is great when you know how many times to repeat, like counting from 1 to 10. A `while` loop runs as long as a condition is true, like asking for input until it’s valid.

Here’s a `for` loop:

    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine(i);
    }
    

This prints 1 to 10. The loop:

*   Starts `i` at 1.
*   Checks if `i <= 10`.
*   Runs the code inside `{}`.
*   Adds 1 to `i` (`i++`) and repeats.

A `while` loop looks like this:

    int number = 0;
    while (number <= 5)
    {
        Console.WriteLine("Number is " + number);
        number++;
    }
    

**What You’ll Do:**

*   Write a program to print “Coding is fun!” five times:

    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine("Coding is fun!");
    }
    

*   Use a `while` loop to keep asking for a positive number:

    Console.WriteLine("Enter a positive number:");
    int num = int.Parse(Console.ReadLine());
    while (num <= 0)
    {
        Console.WriteLine("Please enter a positive number:");
        num = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("Thanks! You entered " + num);
    

**By the End:** You’ll know how to make your programs repeat tasks effortlessly.

### Session 8: Smarter Programs with Loops and Logic 

Now, combine decisions and loops to build more interesting programs. You can put `if` statements inside loops or use `break` to stop a loop early and `continue` to skip a step.

Here’s an example that prints only odd numbers:

    for (int i = 1; i <= 10; i++)
    {
        if (i % 2 == 0) // If i is even
        {
            continue; // Skip to next iteration
        }
        Console.WriteLine(i); // Prints 1, 3, 5, 7, 9
    }
    

**What You’ll Do:**

*   Write a program to print multiples of 3 from 1 to 15:

    for (int i = 1; i <= 15; i++)
    {
        if (i % 3 == 0)
        {
            Console.WriteLine(i); // Prints 3, 6, 9, 12, 15
        }
    }
    

*   Create a number-guessing game:

    int secret = 7; // Could be random later
    Console.WriteLine("Guess a number between 1 and 10:");
    int guess = int.Parse(Console.ReadLine());
    while (guess != secret)
    {
        Console.WriteLine("Wrong! Try again:");
        guess = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("You got it!");
    

**By the End:** You’ll be building programs that think and repeat in clever ways.

Module 4: Writing Reusable Code 
----------------------------------------------------------------------------------

**What’s the Goal?** Organize your code into reusable pieces called methods.  
**How Long?** 2 sessions

### Session 9: Introducing Methods 

Methods are like recipes you can use over and over. Instead of rewriting code, you define a method once and _call_ it whenever you need it. A method looks like this:

    static void SayHello()
    {
        Console.WriteLine("Hello, coder!");
    }
    

You call it in your `Main` method:

    static void Main()
    {
        SayHello(); // Prints: Hello, coder!
        SayHello(); // Prints it again!
    }
    

**What You’ll Do:**

*   Create a method to print a welcome message:

    static void Welcome()
    {
        Console.WriteLine("Welcome to my program!");
    }
    
    static void Main()
    {
        Welcome();
        Console.WriteLine("Let’s code!");
        Welcome();
    }
    

*   Write a method with a parameter to make it flexible:

    static void Greet(string name)
    {
        Console.WriteLine("Hi, " + name + "!");
    }
    
    static void Main()
    {
        Greet("Alex"); // Prints: Hi, Alex!
        Greet("Zoe");  // Prints: Hi, Zoe!
    }
    

**By the End:** You’ll know how to create and use methods to keep your code tidy.

### Session 10: Methods That Do More 

Methods can take inputs (parameters) and give back results (return values). For example:

    static int Square(int number)
    {
        return number * number;
    }
    
    static void Main()
    {
        int result = Square(4); // 4 * 4 = 16
        Console.WriteLine("Square is " + result); // Prints: Square is 16
    }
    

The `return` statement sends a value back, and `int` (instead of `void`) says what type it returns.

**What You’ll Do:**

*   Write a method to add numbers:

    static int Add(int a, int b)
    {
        return a + b;
    }
    
    static void Main()
    {
        int sum = Add(10, 5);
        Console.WriteLine("Sum: " + sum); // Prints: Sum: 15
    }
    

*   Create a method to check if a number is positive:

    static bool IsPositive(int number)
    {
        return number > 0;
    }
    
    static void Main()
    {
        int num = 8;
        if (IsPositive(num))
        {
            Console.WriteLine(num + " is positive!");
        }
    }
    

**By the End:** You’ll be writing methods that process data and make your programs powerful.

Module 5: Building Something Real 
--------------------------------------------------------------------------------------

**What’s the Goal?** Use everything you’ve learned to create a working program.  
**How Long?** 1-2 sessions

### Session 11: Your Capstone Project 

It’s time to shine! You’ll build a small project, like a number-guessing game, combining variables, input, decisions, loops, and methods. Here’s a sample game:

    static void Main()
    {
        Random rand = new Random();
        int secret = rand.Next(1, 11); // Random number 1-10
        int guess;
        Console.WriteLine("Guess the number (1-10):");
        
        do
        {
            guess = int.Parse(Console.ReadLine());
            if (guess < secret)
            {
                Console.WriteLine("Too low! Try again:");
            }
            else if (guess > secret)
            {
                Console.WriteLine("Too high! Try again:");
            }
        } while (guess != secret);
        
        Console.WriteLine("You guessed it!");
    }
    

This uses a `Random` object for the secret number and a `do-while` loop to keep guessing.

**What You’ll Do:**

*   Plan your project (e.g., a guessing game or a simple calculator).
*   Code it step-by-step, testing as you go.
*   Debug any issues (like if the program crashes on bad input).

**By the End:** You’ll have a program you built from scratch—something to show off!

### Session 12 (Optional): Polishing and Planning Ahead 

Let’s make your project even better and think about what’s next. You’ll learn to catch errors with `try-catch`:

    Console.WriteLine("Enter a number:");
    try
    {
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("You entered " + num);
    }
    catch
    {
        Console.WriteLine("That’s not a number!");
    }
    

You’ll also get tips on using Visual Studio’s debugger to find bugs by stepping through code.

**What You’ll Do:**

*   Add a feature to your project, like tracking the number of guesses:

    int tries = 0;
    do
    {
        tries++;
        guess = int.Parse(Console.ReadLine());
        // Rest of guessing logic
    } while (guess != secret);
    Console.WriteLine("You won in " + tries + " tries!");
    

*   Explore next steps, like learning arrays (lists of data) or object-oriented programming.

**By the End:** Your project will feel professional, and you’ll be excited to keep coding.

Wrapping Up the Course 
-----------------------------------------------------------------

You’ll submit your capstone project—a real program you created! There’s no tough grading; we celebrate your effort. You might even get a “Completion of C# Basics” certificate to mark your achievement.

### Tips for Instructors 

*   **Go Slow if Needed:** Some learners may take longer to grasp loops or methods—give them time.
*   **Code, Code, Code:** Every session needs hands-on practice, even if it’s just tweaking examples.
*   **Embrace Mistakes:** Errors are learning opportunities—show how to fix them.
*   **Handy Helper:** Share a syntax cheat sheet (e.g., `if`, `for`, method examples) for quick reference.

* * *

#### This course is your gateway to coding with C#. With variables, loops, decisions, and methods under your belt, you’re ready to tackle bigger challenges. Grab Visual Studio, try the examples, and start building—your coding adventure awaits! 

* * *

### You can follow me on the LinkedIn, YouTube, Telegram Group to discuss, and directly send me email. 

*   [Telegram Group](https://t.me/sadinco_csharp)
*   [LinkedIn](https://linkedin.com/in/MrSadin)
*   [Blog](https://sadin.dev)
*   [YouTube](https://youtube.com/c/EnKamran)