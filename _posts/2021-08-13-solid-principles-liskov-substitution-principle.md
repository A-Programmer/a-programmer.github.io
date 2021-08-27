---
layout: post
title:  "Solid Principles, LSP Liskov Substitution Principle"
date:   2021-08-13 11:20:00 +0430
categories: solid liskov-substitution-principle
---
## Solid Principles
`In Object Oriented Programming there are five design principle called SOLID that helps to keep codes clean and more understandable, flexible and maintainable.`  
In this post i am going to explain first principle called `Single Responsibility Principle (SRP)`.  

1. [SRP - Single Responsibility Principle](https://a-programmer.github.io/solid/single-responsibility-principle/2021/08/11/solid-principles-single-responsibility.html)
2. [OCP - Open Closed Principle](https://a-programmer.github.io/solid/open-closed-principle/2021/08/12/solid-principles-open-closed-principle.html)
3. ### [__*LSP - Liskov Substitution Principle*__](https://a-programmer.github.io/solid/liskov-substitution-principle/2021/08/13/solid-principles-liskov-substitution-principle.html) current
4. [ISP - Interface Segregation Principle](https://a-programmer.github.io/solid/interface-segregation-principle/2021/08/13/solid-principles-interface-segregation-principle-isp.html)
5. [DIP - Dependency Inversion Principle](https://a-programmer.github.io/solid/dependency-inversion-principle/2021/08/14/solid-principles-dependency-inversion-principle-dip.html)

# Liskov Substitution Principle (LSP)
`Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it. "Robert C. Martin"`.  
  
It means if you have a subclass which inherits from a parent class, all parent class members should be usable in subclass and none of them must be unusable.  
For example you are working on a project that there is two type of users, admin and customer, customer users must have subscription type but admin users must have role.  
An admin does not need to subscruption type and a customer does not need to role, ok? Without knowing about LSP rule you will have a class called `User`:  
```
namespace LSP
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public int SubscruptionType { get; set; }
    }
}
```
In this class everywhere you need admin user you have SubscriptionType with object that you don't need and also when you have a customer object it contains Role property while customer doesn't need role!  
Let's modify our class to satisfy LSP rule:  
```
namespace LSP
{
    public class User
    {
        public string Name { get; set; }
    }
}


namespace LSP
{
    public class Admin : User
    {
        public string Role { get; set; }
    }
}


namespace LSP
{
    public class Customer : User
    {
        public int SubscruptionType { get; set; }
    }
}
```

Source code is available [here](https://github.com/A-Programmer/a-programmer.github.io/tree/master/projects/LSP)