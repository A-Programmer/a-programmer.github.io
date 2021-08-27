---
layout: post
title:  "Object Oriented Programming, Part 2, Inheritance and Polymorphism"
date:   2021-08-16 22:30:00 +0430
categories: oop c#
---
# Object Oriented Programming
C# is object-oriented-programming language, there is four basic principles for object-priented-programming:  
- __*Abstraction*__: Modeling the relevant attributes and interactions of entities as classes to define an abstract representation of a system.
- __*Encapsulation*__: Hiding the internal state and functionality of an object and only allowing access through a public set of functions.
- __*Inheritance*__: Ability to create new abstractions based on existing abstractions.
- __*Polymorphism*__: Ability to implement inherited properties or methods in different ways across multiple abstractions.  

In this part we will learn `Inheritance` and `Polymorphism`, we will extend application to add new features to `BankAccount` class.  
As you remember in part 1 of `OOP` we created an application for storing bank accounts but we had only one bank account type, now we need to add new bank account types:  
- An interest earning account that accrues interest at the end of each month.
- A line of credit that can have a negative balance, but when there's a balance, there's an interest charge each month.
- A pre-paid gift card account that starts with a single deposit, and only can be paid off. It can be refilled once at the start of each month.  

All of these accounts are same as `BankAccount` with little differences, the first approach is copy `BankAccount` class and make some changes on each class but it will work in a short time and in the future you will have a messy code. So what is the best way? We can use inheritance, We can create new class for each type that inherites from `BankAccount` class. These new classes can extend the `BankAccount` class to have new features and behavior that they need.  

```
public class InterestedEaringAccount : BankAccount
{

}

public class LineOfCreditAccount : BankAccount
{

}

public class GiftCardccount : BankAccount
{

}
```

Now each class has base class (BankAccount) abilities and it can add new features for itself.  
After adding these classes you will see that application will not build because a drived class constructor must initialize the derived class and instructions on how to initialize the base class object included in the dericed class. Each derived class must explcitly call base class constructor:  

```
public InterestEaringAccount(string name, decimal initialBalance)
    : base(name, initialBalance)
    {

    }
```

The parameters to this new constructor match the parameter type and names of the base class constructor. You use the `: base()` syntax to indicate a call to a base class constructor. Some classes define multiple constructors, and this syntax enables you to pick which base class constructor you call. Once you've updated the constructors, you can develop the code for each of the derived classes. The requirements for the new classes can be stated as follows:

- An interest earning account:
  - Will get a credit of 2% of the month-ending-balance.
- A line of credit:
  - Can have a negative balance, but not be greater in absolute value than the credit limit.
  - Will incur an interest charge each month where the end of month balance isn't 0.
  - Will incur a fee on each withdrawal that goes over the credit limit.
- A gift card account:
  - Can be refilled with a specified amount once each month, on the last day of the month.  
  
You can see that all three of these account types have an action that takes places at the end of each month. However, each account type does different tasks. You use polymorphism to implement this code. Create a single virtual method in the BankAccount class:

```
public virtual void PerformMonthEndTransactions() { }
```

`virtual` helps to declare a method in base class and derived class can provide a different implementation. A `virtula` method is a method where any derived class mya choose to reimplement. In the derived class we use `override` keyword to define a new implementation. Also we can declare `abstract` methods where derived class must override the behavior. Remember the base class does not provide an implementation for an `abstract` class method. So let's add this method to our derived classes:  

```
//InterestEaringAccount
public override void PerformMonthEndTransactions()
{
    if(Balance > 500m)
    {
        var interest = Balance * 0.05m;
        Depostit(interest, "Apply monthly interest");
    }
}

//LineOfCreditAccount
public override void PerformMonthEndTransactions()
{
    if(Balance < 0)
    {
        var interest = -Balance * 0.07m;
        Withdrae(interest, "Charge monthly interest");
    }
}

``` 
The `GiftCardAccount` class needs two changes to implement its month-end functionality. First modify constructor to include optional amount to add each month:  

```
private decimal _monthlyDepost = 0m;

public GiftCardAccount(string name, decimal initualBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _monthlyDeposit = monthluDeposit;
```
And next we should add `PerformMonthEndTransactions` method to add the monthly deposit:  

```
public override void PerformMonthEndTransactions()
{
    if(_monthlyDeposit != 0)
        Deposit(_monthlyDeposit, "Add monthly deposit");
}
```

So let's use these classes in `Program` class to test functionality:  

```
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.Deposit(20, "get expensive coffee");
giftCard.Withdraw(50, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.Deposit(27.50m, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.Deposit(750, "save some money");
savings.Deposit(1250, "Add more savings");
savings.Withdraw(250, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0);
// How much is too much to borrow?
lineOfCredit.Withdraw(1000m, "Take out monthly advance");
lineOfCredit.Deposit(50m, "Pay back small amount");
lineOfCredit.Withdraw(5000m, "Emergency funds for repairs");
lineOfCredit.Deposit(150m, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());
```

When you add the preceding code and run the program, you'll see error.  
This code fails because the BankAccount assumes that the initial balance must be greater than 0. Another assumption baked into the BankAccount class is that the balance can't go negative. Instead, any withdrawal that overdraws the account is rejected. Both of those assumptions need to change. The line of credit account starts at 0, and generally will have a negative balance. Also, if a customer borrows too much money, they incur a fee. The transaction is accepted, it just costs more. The first rule can be implemented by adding an optional argument to the BankAccount constructor that specifies the minimum balance. The default is 0. The second rule requires a mechanism that enables derived classes to modify the default algorithm. In a sense, the base class "asks" the derived type what should happen when there's an overdraft. The default behavior is to reject the transaction by throwing an exception.  

Let's start by adding a second constructor that includes an optional minimumBalance parameter. This new constructor does all the actions done by the existing constructor. Also, it sets the minimum balance property. You could copy the body of the existing constructor. but that means two locations to change in the future. Instead, you can use constructor chaining to have one constructor call another. The following code shows the two constructors and the new additional field:

```
private readonly decimal minimumBalance;

public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
{
    this.Number = _generateNumber();

    this.Owner = name;
    this.minimumBalance = minimumBalance;
    if (initialBalance > 0)
        Deposit(initialBalance, "Initial balance");
}
```

The preceding code shows two new techniques. First, the minimumBalance field is marked as readonly. That means the value cannot be changed after the object is constructed. Once a BankAccount is created, the minimumBalance can't change. Second, the constructor that takes two parameters uses : this(name, initialBalance, 0) { } as its implementation. The : this() expression calls the other constructor, the one with three parameters. This technique allows you to have a single implementation for initializing an object even though client code can choose one of many constructors.  

This implementation calls Deposit only if the initial balance is greater than 0. That preserves the rule that deposits must be positive, yet lets the credit account open with a 0 balance.  

Now that the BankAccount class has a read-only field for the minimum balance, the final change is to change the hard code 0 to minimumBalance in the withdrawal method:  

```
if (Balance - amount < minimumBalance)
```

After extending the BankAccount class, you can modify the LineOfCreditAccount constructor to call the new base constructor, as shown in the following code:  

```
public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
{
}
```

Notice that the LineOfCreditAccount constructor changes the sign of the creditLimit parameter so it matches the meaning of the minimumBalance parameter.  

## Different overdraft rules
The last feature to add enables the LineOfCreditAccount to charge a fee for going over the credit limit instead of refusing the transaction.  

One technique is to define a virtual function where you implement the required behavior. The BankAccount class refactors the withdrawal method into two methods. The new method does the specified action when the withdrawal takes the balance below the minimum. The existing Withdraw method has the following code:  

```
public void Withdraw(decimal amount, DateTime date, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    }
    if (Balance - amount < minimumBalance)
    {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    }
    var withdrawal = new Transaction(-amount, date, note);
    transactions.Add(withdrawal);
}
```

Replace it with the following code:  

```
public void Withdraw(decimal amount, DateTime date, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    }
    var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
    var withdrawal = new Transaction(-amount, date, note);
    transactions.Add(withdrawal);
    if (overdraftTransaction != null)
        transactions.Add(overdraftTransaction);
}

protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
{
    if (isOverdrawn)
    {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    }
    else
    {
        return default;
    }
}
```  

The added method is protected, which means that it can be called only from derived classes. That declaration prevents other clients from calling the method. It's also virtual so that derived classes can change the behavior. The return type is a Transaction?. The ? annotation indicates that the method may return null. Add the following implementation in the LineOfCreditAccount to charge a fee when the withdrawal limit is exceeded:  

```
protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;
```

The override returns a fee transaction when the account is overdrawn. If the withdrawal doesn't go over the limit, the method returns a null transaction. That indicates there's no fee. Test these changes by adding the following code to your Main method in the Program class:  

```
var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
// How much is too much to borrow?
lineOfCredit.Withdraw(1000m, "Take out monthly advance");
lineOfCredit.Deposit(50m, "Pay back small amount");
lineOfCredit.Withdraw(5000m, "Emergency funds for repairs");
lineOfCredit.Deposit(150m, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());
```  
Run the program, and check the results.  
This post is copy of microsoft documention.