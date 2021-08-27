using System;

namespace Oop_01
{
    public class Transaction
    {
        public Transaction(decimal amount, string note)
        {
            this.Amount = amount;
            this.Note = note;
            this.Date = DateTime.Now;
        }

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Note { get; }
    }
}