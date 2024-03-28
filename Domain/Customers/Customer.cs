namespace Domain.Customers;
public record CustomerId(Guid value);
public class Customer
{
    public CustomerId Id { get; private set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
,
//Primptive Obsession