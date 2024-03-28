namespace Domain.Products;
public record Sku
{
    private Sku(string value) => Value = value;
    public string Value { get; init; }
    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value)) return null;

        if (value.Length != 15)
        {
            return null;
        }

        return new Sku(value);
    }
}



