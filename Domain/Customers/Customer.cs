namespace Domain.Customers
{
    public class Customer
    {
        public Guid Id { get;private set; }
        public string Email { get; set; }=string.Empty;
        public string Name { get; set; } = string.Empty;

    }
}
