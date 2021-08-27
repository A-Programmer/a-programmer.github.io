using System;
using System.Collections.Generic;

namespace Oop_01
{
    public class BankAccount
    {
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

        public string Number { get; }
        public string Owner { get; }
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

        private List<Transaction> transactions = new List<Transaction>();

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
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, note);
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

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\t\tAmount\tBalance\tNote");
            foreach(var transaction in transactions)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToString()}\t{transaction.Amount}\t{balance}\t{transaction.Note}");
            }

            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions() { }

        private string _generateNumber()
        {
            var random = new Random();
            return random.Next(100, 999).ToString();
        }
    }
}