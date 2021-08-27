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