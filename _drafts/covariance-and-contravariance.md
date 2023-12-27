---
layout: post
title: Covariance and Contravariance
description:
image:
category:
tags:
---
Covariance and Contraviance are a bit difficualt topics to understand, it's a bit complecated to explain without understanding some concepts like object creation, variables, and generics. 

What will happen if I run the following code:

```csharp
public class Animal
{

}
public class Cat : Animal
{

}

Cat cat = new Cat();
```

When we run this code, we are creating an object of a Cat blueprint/template (an actual object from a template) on the memory, somewhere on the memory. We dont care about name, just object is created! This object is storing somewhere on the memory, right? So we need a way to access it, right? How about having an address of the block of the memory?
So we have an stored object on the memory that has an address.
Then we are creating a variable, its just a variable nothing else. Now we need to comnect this variable and the created object.
We are putting the address of that object into this variable.
Whats the point?
Pay attention, the cat variable has a shape of Cat class, because of this part "Cat cat", this part says that I am having a Cat variable (shape) so when I am trying to call something like cat.Walk() it works fine if the Cat class has a Walk member because the Cat has a member Walk, now how about this:
```csharp
public class Animal
{
    public void Move() => Console.WriteLine("The animal is moving");
}
public class Cat : Animal
{
    piblic void Walk() => Console.WriteLine("Cat is walking");
}
Cat cat = new Animal();
cat.Move(); //is this legal?
```
We will get a compilation error! Doesnt Animal have a Move member? It does but the shape of cat is Cat => "Cat cat..." Cat class doesnt have a Move member, when we are calling cat, we are calling the reference through the Cat shape/template/blueprint and Cat shape/template/blueprint doesnt have Move member!
this was part of the Covariance and Contravariance article that I am working on it (Not Co/Contravariance, but underestanding how the variable and object creation works is needed to understand the Co/Contravariance)
