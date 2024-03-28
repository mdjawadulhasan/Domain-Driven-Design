using Domain.Products;

namespace Domain.Orders;
public record LineItemId(Guid value);
public class LineItem
{
    public LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
    {
        lineItemId = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    public LineItemId lineItemId { get; private set; }
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public Money Price { get; private set; }
}