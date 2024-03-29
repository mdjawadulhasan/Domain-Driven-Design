namespace Domain.Products;
public record ProductId(Guid value);
public record Money(string Currency, decimal Amount);

public class Product
{
    public ProductId ProductId { get; private set; }
    public string Name { get; set; } = string.Empty;
    public Money Price { get; private set; }
    public Sku Sku { get; private set; }
}

