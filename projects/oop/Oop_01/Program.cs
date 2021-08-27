using System;

namespace Oop_01
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.Withdraw(1000m, "Take out monthly advance");
            lineOfCredit.Deposit(50m, "Pay back small amount");
            lineOfCredit.Withdraw(5000m, "Emergency funds for repairs");
            lineOfCredit.Deposit(150m, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}
