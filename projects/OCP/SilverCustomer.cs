namespace OCP
{
    public class SilverCustomer : Customer
    {
        public override double GetDiscount(Customer customer)
        {
            return (customer.TotalSales / 100) * customer.CustomerType;
        }

    }
}