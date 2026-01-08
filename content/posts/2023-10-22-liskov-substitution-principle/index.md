---
date: '2023-10-22T11:48:27+03:30'
draft: false
title: 'SOLID - Liskov Substitution Principle'
tags: ["abstract", "csharp", "dotnet", "basics", "lsp","liskov_substitution_principle","solid"]
categories: ["csharp", "solid"]
description: "The Liskov Substitution Principle defines that objects of a derived class should be substitutable for objects of the base class without affecting the correctness of the program. In simpler terms, any instance of a base class should be replaceable with an instance of a derived class without altering the desired properties of the program."
---
In the realm of software design, adhering to fundamental principles is essential for creating maintainable, flexible, and scalable codebases. One such crucial principle is the **Liskov Substitution Principle (LSP)**. LSP is a key element of the SOLID principles, initially introduced by Barbara Liskov. Understanding and applying the Liskov Substitution Principle is fundamental to achieving robust and extensible software systems.

1.  [Introduction](https://sadin.dev/posts/mastering-solid-principles-in-csharp/?)
2.  [Single Responsibility Principle](https://sadin.dev/posts/single-responsibility-principle/?)
3.  [Open/Closed Principle](https://sadin.dev/posts/open-closed-principle/?)
4.  [**Liskov Substitution Principle**](https://sadin.dev/posts/liskov-substitution-principle/?)
5.  [Interface Segregation Principle](https://sadin.dev/posts/interface-segregation-principle/?)
6.  [Dependency Inversion Principle](https://sadin.dev/posts/dependency-inversion-principle/?)

What is the Liskov Substitution Principle? 
--------------------------------------------------------------------------------------------------------

The Liskov Substitution Principle defines that objects of a derived class should be substitutable for objects of the base class without affecting the correctness of the program. In simpler terms, any instance of a base class should be replaceable with an instance of a derived class without altering the desired properties of the program.

How Does LSP Help Us? 
--------------------------------------------------------------

The Liskov Substitution Principle offers several benefits:

### 1\. **Behavioral Consistency:** 

*   By adhering to LSP, developers can trust that derived classes will behave consistently with the base class, reducing unexpected behavior and bugs.

### 2\. **Enhanced Reusability:** 

*   LSP encourages the creation of classes that can be used interchangeably, promoting code reuse and preventing unnecessary duplication.

### 3\. **Design Flexibility:** 

*   By adhering to the principle, the system’s design becomes more flexible, allowing for easy addition of new derived classes or modifications to existing ones.

Consequences of Not Using LSP 
-------------------------------------------------------------------------------

If the Liskov Substitution Principle is violated, several issues may arise:

*   **Unexpected Behavior:**
    
    *   Objects of derived classes may exhibit unexpected behavior, breaking the assumptions made in the base class and causing errors.
*   **Complexity:**
    
    *   Violating LSP can introduce unnecessary complexity into the system, making it challenging to understand and maintain.
*   **Code Delicacy:**
    
    *   Code that does not adhere to LSP tends to be more delicate and prone to errors, making it difficult to predict its behavior.

LSP and Complex Software 
---------------------------------------------------------------------

In large, complex software systems, adherence to the Liskov Substitution Principle is vital. As systems grow, ensuring that derived classes can seamlessly substitute their base classes without altering the program’s correctness becomes crucial for maintaining a stable and predictable system.

Examples of LSP in Action 
-----------------------------------------------------------------------

Let’s illustrate LSP with three simple examples:

### 1\. **Rectangle and Square:** 

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    
        public int Area()
        {
            return Width * Height;
        }
    }
    
    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
    
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
    

In this example, `Square` inherits from `Rectangle` but violates LSP since changing the width of a `Square` will also affect its height, breaking the expected behavior of a `Rectangle`.

### 2\. **Bird and Ostrich:** 

    public class Bird
    {
        public virtual void Fly()
        {
            // Flying logic
        }
    }
    
    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new InvalidOperationException("Ostriches cannot fly.");
        }
    }
    

Here, `Ostrich` inherits from `Bird` but violates LSP by throwing an exception in its `Fly` method, which is unexpected behavior for a derived class of `Bird`.

### 3\. **Stack:** 

    public class Stack
    {
        private List<int> stack = new List<int>();
    
        public virtual void Push(int item)
        {
            stack.Add(item);
        }
    
        public int Pop()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
            var lastIndex = stack.Count - 1;
            var item = stack[lastIndex];
            stack.RemoveAt(lastIndex);
            return item;
        }
    }
    
    public class LimitedStack : Stack
    {
        public override void Push(int item)
        {
            if (stack.Count >= 10)
                throw new InvalidOperationException("Stack limit exceeded.");
            base.Push(item);
        }
    }
    

In this example, `LimitedStack` inherits from `Stack` but violates LSP by altering the behavior of the `Push` method, which contradicts the behavior of the base class.

Summary 
-----------------------------------

The Liskov Substitution Principle is a fundamental guideline in software design, ensuring that derived classes can substitute their base classes without altering the correctness of the program. Adhering to LSP enhances behavioral consistency, reusability, and design flexibility. By understanding and implementing this principle, developers can create software systems that are predictable, maintainable, and easily extendable over time.

You can follow me on the LinkedIn, YouTube, Telegram Group to discuss, and directly send me email. 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*   [Telegram Group](https://t.me/sadinco_csharp)
*   [LinkedIn](https://linkedin.com/in/MrSadin)
*   [Blog](https://blog.sadin.dev)
*   [YouTube](https://youtube.com/c/EnKamran)