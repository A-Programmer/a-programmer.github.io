---
layout: post
title:  "Solid Principles, OCP Open Closed Principle"
date:   2021-08-12 11:20:00 +0430
categories: solid open-closed-principle
---
## SOLID Principles
`In Object Oriented Programming there are five design principle called SOLID that helps to keep codes clean and more understandable, flexible and maintainable.`  
In this post i am going to explain first principle called `Single Responsibility Principle (SRP)`.  

1. [SRP - Single Responsibility Principle](https://a-programmer.github.io/solid/single-responsibility-principle/2021/08/11/solid-principles-single-responsibility.html)
2. ### [__*OCP - Open Closed Principle*__](https://a-programmer.github.io/solid/open-closed-principle/2021/08/12/solid-principles-open-closed-principle.html) current
3. [LSP - Liskov Substitution Principle](https://a-programmer.github.io/solid/liskov-substitution-principle/2021/08/13/solid-principles-liskov-substitution-principle.html)
4. [ISP - Interface Segregation Principle](https://a-programmer.github.io/solid/interface-segregation-principle/2021/08/13/solid-principles-interface-segregation-principle-isp.html)
5. [DIP - Dependency Inversion Principle](https://a-programmer.github.io/solid/dependency-inversion-principle/2021/08/14/solid-principles-dependency-inversion-principle-dip.html)

# Open Closed Principle
`Software classes, modules, functions, ... should be open for extension but closed for modification.`  
Let me go on with an example:  
In our application we have a class for customers called `Customer`:  
```
public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CustomerType { get; set; }

    public double GetDiscount(double totalSales)
    {
        if(CustomerType == 1)
        {
            return (totalSales / 100) * 10;
        }
        else
        {
            return (totalSales / 100) * 5;
        }
    }
}
```
As you can see in `Customer` class i have a field for customer type which it can be 1 for Gold or 2 for Silver, It seems ok and works fine but as your business grows up we need to add another type of customer let's say 3, now what should we do? We should add another if statement and this is the problem! we are modifying existing method, think about it, in big applications it may cause to be broken other parts of project, this rule say's that your class should not modify but it can be extended. So let's change our class to fix this problem:
```
namespace OCP
{
    public abstract class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double TotalSales { get; set; }
        public int CustomerType { get; set; }
        public abstract double GetDiscount(Customer customer);
    }
}


namespace OCP
{
    public class GoldenCustomer : Customer
    {

        public override double GetDiscount(Customer customer)
        {
            return (customer.TotalSales / 100) * customer.CustomerType;
        }
    }
}


namespace OCP
{
    public class SilverCustomer : Customer
    {
        public override double GetDiscount(Customer customer)
        {
            return (customer.TotalSales / 100) * customer.CustomerType;
        }

    }
}
```
Great!! Now we can add any type that we need just by adding new class and inherit from `Customer` class.  

Let me say another example:  
We want to calculate area, So we add a cass called `AreaCaculator` like this:  
```
public class AreaCalculator
{
    public double Area(object shape)
    {
        if(shape is Rectangle)
        {
            Rectangle rectangle = (Rectangle) shape;
            return rectangle.Width * rectangle.Height;
        }
        else
        {
            Circle circle = (Circle) shape;
            return circle.Radius * circle.Radius * Math.PI;
        }
    }
}

public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
}


public class Circle
{
    public double Radius { get; set; }
}
```
Now what if i need to add another shape? I should add another if statement to `AreaCalculator` which is not a good choice. I prefer to change my classes like this:  
```
public abstract class Shape
{
    public abstract double Area();
}
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double Area()
    {
        return Width*Height;
    }
}
public class Circle : Shape
{
    public double Radius { get; set; }
    public override double Area()
    {
        return Radius*Radius*Math.PI;
    }
}
```
Now i have a base class called Shape and i create my shapes and inherit from Shape class, it means that if i need to add new feature it is ok and it is simple and does not need to change or modify my existing methods. `It is open for extension but closed for modification`.  
Source code is available [here](https://github.com/A-Programmer/a-programmer.github.io/tree/master/projects/OCP)