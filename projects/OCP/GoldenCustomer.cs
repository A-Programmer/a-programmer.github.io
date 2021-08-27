namespace OCP
{
    public class GoldenCustomer : Customer
    {

        public override double GetDiscount(Customer customer)
        {
            return (customer.TotalSales / 100) * customer.CustomerType;
        }
    }
}