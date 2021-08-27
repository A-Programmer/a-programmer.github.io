---
layout: post
title:  "Object Oriented Programming, Part 1, Abstraction and Encapsulation"
date:   2021-08-15 22:20:00 +0430
categories: oop c#
---
# Object Oriented Programming
C# is object-oriented-programming language, there is four basic principles for object-priented-programming:  
- __*Abstraction*__: Modeling the relevant attributes and interactions of entities as classes to define an abstract representation of a system.
- __*Encapsulation*__: Hiding the internal state and functionality of an object and only allowing access through a public set of functions.
- __*Inheritance*__: Ability to create new abstractions based on existing abstractions.
- __*Polymorphism*__: Ability to implement inherited properties or methods in different ways across multiple abstractions.  

Let's start by an example, we want to create an application for Bank. We wabt to store customers account information. Object Oriented Programming organizes code by creating types in the form of `class`. The `BankAccount` class represents a bank acount. For the sake of simplicity we create our `BankAccount` class like this:  

```
public class BankAccount
{
    public string Number { get; set; }
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(decimal amount, string note)
    {
        // ...
    }

    public void Withdraw(decimal amount, string note)
    {
        // ...
    }
}
```  
This class should have this abilities or let's say behaviors:  
- It has a 3-digit number that identifies the bank account.
- It has owner name.
- It showes current balance of an account.
- We can deposit and withdraw.
- The initial balance must be positive.
- Withdrawals can not result in a negative balance.  
  
At the first we need to open a new account, right? We are going to use `Constructor`, So let's add a constructor to our class like this:

```
public class BankAccount
{
    public BankAccount(string name, decimal initialBalance)
    {
        if(initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial amount must be greater than 0.");
        this.Owner = name;
        this.Balance = initialBalance;
    }

    public string Number { get; set; }
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(decimal amount, string note)
    {
        // ...
    }

    public void Withdraw(decimal amount, string note)
    {
        // ...
    }
}
```  
There is one more thing, here we didn't set account number and it should be assigned when the object is constructed but the caller should not assign it, it should assign automatically and for this `BankAccount` should know how to assign new Account Number. Let's create a private method to generate a random number for `Number` property and use it in out construtor:  

```
public class BankAccount
{
    public BankAccount(string name, decimal initialBalance)
    {
        if(initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial amount must be greater than 0.");
        this.Owner = name;
        this.Balance = initialBalance;
        this.Number = _generateNumber();
    }

    public string Number { get; }
    public string Owner { get; }
    public decimal Balance { get; }

    public void Deposit(decimal amount, string note)
    {
        // ...
    }

    public void Withdraw(decimal amount, string note)
    {
        // ...
    }

    private string _generateNumber()
    {
        var random = new Random();
        return random.Next(100, 999).ToString();
    }
}
```

Now everytime we create a new object of BankAccount it will assign a new Number, yes we should not have duplicate Number but for now we leave it as it is.  
### Deposit and Withdraw
We should be able to make deposit and withdraw, For this we need to store transaction, So we should create a class called `Transaction` like this:  

```
public class Transaction
{
    public Transaction(decimal amount, string note)
    {
        this.Amount = amount;
        this.Note = note;
        this.Date = DateTime.Now;
    }

    public decimal Amount { get; }
    public string Note { get; }
    public DateTime Date { get; }
}
```
And add `List<T>` of `Transaction` objects to `BankAccount` class:

```
private List<Transaction> transactions = new List<Transaction>();
```

Then modify the `Balance` property to get the balance correctly:  

```
public decimal Balance
{
    get
    {
        decimal balance = 0;
        foreach(var transaction in transactions)
        {
            balance += transaction.Amount;
        }

        return balance;
    }
}
```

As you can see we create all properties setters as private which means you can not set value directly from outside of class, this was abstraction:  

```
class Program
    {
        static void Main(string[] args)
        {
            //Wrong way:
            var acc = new BankAccount();
            acc.Number = 111;
            acc.Owner = "Kamran Sadin";
            acc.Balance = 2000;

            //Right way
            var account = new BankAccount("Kamran Sadin", 0);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner}, Account Number is: {account.Number}");
        }
    }
```

Here we used encapsulation, it means make properties private and create methods for changing properties values.  
Now let's modify `Deposit` and `Withdraw` methods:  

```
public void Deposit(decimal amount, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
    }
    var deposit = new Transaction(amount, note);
    transactions.Add(deposit);
}

public void Withdraw(decimal amount, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    }
    if (Balance - amount < 0)
    {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    }
    var withdrawal = new Transaction(-amount, date, note);
    transactions.Add(withdrawal);
}
```
A little more change for `BankAccount` constructor:  
```
public class BankAccount
{
    public BankAccount(string name, decimal initialBalance)
    {
        if(initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial amount must be greater than 0.");
        this.Owner = name;
        this.Number = _generateNumber();
        Deposit(initialBalance, "Initial balance");
    }
    
    //...

}
```

One last thing is adding a method to get account history, add this method to `BankAccount` class:  

```
public string GetAccountHistory()
{
    var report = new System.Text.StringBuilder();

    decimal balance = 0;
    report.AppendLine("Date\t\tAmount\tBalance\tNote");
    foreach(var transaction in transactions)
    {
        balance += transaction.Amount;
        report.AppendLine($"{transaction.Date.ToString()}\t{transaction.Amount}\t{balance}\t{transaction.Note}");
    }

    return report.ToString();
}
```
Here is `Program.cs` file:  
```
class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kamran Sadin", 100);
            
            account.Deposit(150, "Deposit 1");
            account.Deposit(10, "Deposit 2");
            account.Deposit(79, "Deposit 3");

            account.Withdraw(50,"Withdraw 1");
            account.Withdraw(20,"Withdraw 2");
            account.Withdraw(94,"Withdraw 3");

            Console.WriteLine(account.GetAccountHistory());

            Console.WriteLine($"Total balance: {account.Balance}");

            Console.WriteLine($"Account {account.Number} was created for {account.Owner}, Account Number is: {account.Number}");
        }
    }
```
More details is available [here](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes)  
[Source code](https://github.com/A-Programmer/a-programmer.github.io/tree/master/projects/oop/Oop_01)