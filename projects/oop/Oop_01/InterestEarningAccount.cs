
namespace Oop_01
{
    public class InterestEarningAccount : BankAccount
    {

        public InterestEarningAccount(string name, decimal initialBalance)
            : base(name, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                Deposit(interest, "apply monthly interest");
            }
        }
    }
}