---
layout: post
title:  "Solid Principles, ISP Interface Segregation Principle"
date:   2021-08-13 14:30:00 +0430
categories: solid interface-segregation-principle
---
## Solid Principles
`In Object Oriented Programming there are five design principle called SOLID that helps to keep codes clean and more understandable, flexible and maintainable.`  
In this post i am going to explain first principle called `Single Responsibility Principle (SRP)`.  

1. [SRP - Single Responsibility Principle](https://a-programmer.github.io/solid/single-responsibility-principle/2021/08/11/solid-principles-single-responsibility.html)
2. [OCP - Open Closed Principle](https://a-programmer.github.io/solid/open-closed-principle/2021/08/12/solid-principles-open-closed-principle.html)
3. [LSP - Liskov Substitution Principle](https://a-programmer.github.io/solid/liskov-substitution-principle/2021/08/13/solid-principles-liskov-substitution-principle.html)
4. ### [__*ISP - Interface Segregation Principle*__](https://a-programmer.github.io/solid/interface-segregation-principle/2021/08/13/solid-principles-interface-segregation-principle-isp.html) current
5. [DIP - Dependency Inversion Principle](https://a-programmer.github.io/solid/dependency-inversion-principle/2021/08/14/solid-principles-dependency-inversion-principle-dip.html)

# Interface Segregation Principle (ISP)
`No client should be forced to implement methods which it does not use and the contracts should be broken down to thin ones.`  
It means create contracts with methods which every client who inherites from this contract needs all methods and you should not have any client that implements a contract with methods that it does not need them.  
The `ISP` helps to have clean and simple contracts, and makes contracts more readable, Prevents creating big interfaces with many method definitions.  
You sould not force derived classes to implement methods that don't need them, instead of having one big and messy interface create some clean and small interfaces.  
In this example I have `IOrder` interface which contains two methods called `AddToCart` and `PaypalPayment`, It looks fine, then I have two order types called `OnlineOrder` and `OfflineOrder`, So in online orders it works fine and there is no problem but in offline orders we don't have any online payment and `PaypalPayment` should not implement and throw an exception:

```
namespace ISP
{
    public interface IOrder
    {
        void AddToCart();
        void PaypalPayment();
    }
}

using System;
namespace ISP
{
    public class OnlineOrder : IOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("Product has been added to cart.");
        }

        public void PaypalPayment()
        {
            Console.WriteLine("Redirect user to Paypal gateway ...");
        }
    }
}

using System;
namespace ISP
{
    public class OfflineOrder : IOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("Product has been added to cart.");
        }

        public void PaypalPayment()
        {
            throw new InvalidOperationException("There is no payment method for offline orders");
        }
    }
}
```

I think you get the point, now let's change interface and classes to make it right:

```
namespace ISP
{
    public interface IOrder
    {
        void AddToCart();
    }
}

namespace ISP
{
    public interface IOnlineOrder
    {
        void PaypalPayment();
    }
}

using System;
namespace ISP
{
    public class OnlineOrder : IOrder, IOnlineOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("Product has been added to cart.");
        }

        public void PaypalPayment()
        {
            Console.WriteLine("Redirect user to Paypal gateway ...");
        }
    }
}

using System;
namespace ISP
{
    public class OfflineOrder : IOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("Product has been added to cart.");
        }
    }
}

using System;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineOrder onlineOrder = new OnlineOrder();
            onlineOrder.AddToCart();
            onlineOrder.PaypalPayment();

            Console.WriteLine("-----------");

            OfflineOrder offlineIrder = new OfflineOrder();
            offlineIrder.AddToCart();
        }
    }
}

```
Now it seems right, Source code is available [here](https://github.com/A-Programmer/a-programmer.github.io/tree/master/projects/ISP)