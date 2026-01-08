---
date: '2023-10-20T11:47:52+03:30'
draft: false
title: 'SOLID - Open Closed Principle'
tags: ["abstract", "csharp", "dotnet", "basics", "ocp","open_closed_principle","solid"]
categories: ["csharp", "solid"]
description: "The Open/Closed Principle emphasizes that software entities (classes, modules, functions, etc.) should be open for **extension but closed for modification**. In simpler terms, the behavior of a module can be extended without modifying its source code. This principle promotes the creation of a system that is both adaptable and sustainable over time."
---
In the realm of software design, certain principles serve as guiding lights for creating maintainable, flexible, and scalable codebases. One such foundational principle is the **Open/Closed Principle (OCP)**. OCP is a crucial component of the SOLID principles, initially introduced by Bertrand Meyer. Understanding and applying the Open/Closed Principle can significantly impact software design.

1.  [Introduction](https://sadin.dev/posts/mastering-solid-principles-in-csharp/?)
2.  [Single Responsibility Principle](https://sadin.dev/posts/single-responsibility-principle/?)
3.  [**Open/Closed Principle**](https://sadin.dev/posts/open-closed-principle/?)
4.  [Liskov Substitution Principle](https://sadin.dev/posts/liskov-substitution-principle/?)
5.  [Interface Segregation Principle](https://sadin.dev/posts/interface-segregation-principle/?)
6.  [Dependency Inversion Principle](https://sadin.dev/posts/dependency-inversion-principle/?)

What is the Open/Closed Principle? 
---------------------------------------------------------------------------------------

The Open/Closed Principle emphasizes that software entities (classes, modules, functions, etc.) should be open for **extension but closed for modification**. In simpler terms, the behavior of a module can be extended without modifying its source code. This principle promotes the creation of a system that is both adaptable and sustainable over time.

How Does OCP Help Us? 
--------------------------------------------------------------

The Open/Closed Principle offers several benefits:

### 1\. **Code Reusability:** 

*   By extending existing modules rather than modifying them, developers can reuse tried and tested code, reducing the likelihood of introducing new bugs.

### 2\. **Minimized Risk:** 

*   Since existing, well-tested code remains untouched, the risk of introducing errors during modification is significantly reduced. New functionality is added through extensions, minimizing potential regressions.

### 3\. **Maintainability:** 

*   Code that follows the Open/Closed Principle is easier to maintain. Changes and enhancements are isolated to new code, preserving the stability and integrity of the existing codebase.

Consequences of Not Using OCP 
-------------------------------------------------------------------------------

If the Open/Closed Principle is ignored, several issues may arise:

*   **Frequent Modification:**
    
    *   Without adhering to OCP, every change in requirements may force modifications to existing code, leading to a perpetual cycle of updates and potential bugs.
*   **Increased Risk:**
    
    *   Modifying existing code increases the risk of introducing bugs or unintentionally altering existing functionality, causing unforeseen consequences.
*   **Complexity and Maintenance Challenges:**
    
    *   Codebases lacking adherence to OCP tend to become increasingly complex and difficult to maintain as more modifications are made.

OCP and Complex Software 
---------------------------------------------------------------------

In large, complex software systems, the Open/Closed Principle is crucial. As requirements evolve and new features are introduced, adhering to OCP ensures that the system remains extensible without risking the stability of existing features.

Examples of OCP in Action 
-----------------------------------------------------------------------

Let’s illustrate OCP with three simple examples:

### 1\. **Shape Calculation:** 

    public abstract class Shape
    {
        public abstract double Area();
    }
    
    public class Circle : Shape
    {
        private readonly double radius;
    
        public Circle(double radius)
        {
            this.radius = radius;
        }
    
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
    }
    

Here, the `Shape` class is open for extension, allowing the addition of new shapes like `Circle` without modifying the existing `Shape` class.

### 2\. **Sort Algorithm:** 

    public class Sorter
    {
        public void Sort(int[] arr)
        {
            // Sort array using a specific algorithm
        }
    }
    

In this example, the `Sorter` class can be extended to support various sorting algorithms (e.g., merge sort, quicksort) without modifying the `Sorter` class itself.

### 3\. **Notification Service:** 

    public interface INotificationService
    {
        void SendNotification(string message);
    }
    

Here, the `INotificationService` interface can be implemented by various notification methods (email, SMS, etc.) without modifying the interface itself.

Summary 
-----------------------------------

The Open/Closed Principle is a fundamental guideline in software design, advocating for software entities to be open for extension but closed for modification. Adhering to OCP enhances code reusability, minimizes risks, and improves maintainability. By understanding and implementing this principle, developers can create software systems that are adaptable, scalable, and easier to extend over time.

You can follow me on the LinkedIn, YouTube, Telegram Group to discuss, and directly send me email. 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*   [Telegram Group](https://t.me/sadinco_csharp)
*   [LinkedIn](https://linkedin.com/in/MrSadin)
*   [Blog](https://blog.sadin.dev)
*   [YouTube](https://youtube.com/c/EnKamran)