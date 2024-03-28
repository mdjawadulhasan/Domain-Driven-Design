using Domain.Customers;
using Domain.Products;
namespace Domain.Orders;

public record OrderId(Guid value);
public class Order
{
    private readonly HashSet<LineItem> _items = new();
    public OrderId orderId { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public static Order Create(CustomerId customerId)
    {
        var order = new Order()
        {
            orderId = new OrderId(Guid.NewGuid()),
            CustomerId = customerId
        };
        return order;
    }

    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), orderId, productId, price);
        _items.Add(lineItem);
    }
}























/*
[HttpPost]
public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
{
    // 1. Validate the customer exists (call Customer Microservice)
    var customerExists = await _customerServiceClient.CheckCustomerExists(request.CustomerId);
    if (!customerExists)
    {
        return BadRequest("Invalid customer ID.");
    }

    // 2. Validate products and get prices (call Product Microservice)
    var productPrices = await _productServiceClient.GetProductsAndPrices(request.ProductIds);
    if (productPrices.Count != request.ProductIds.Count)
    {
        return BadRequest("One or more products are invalid.");
    }

    // 3. Create order and line items
    var order = new Order(Guid.NewGuid(), request.CustomerId);
    foreach (var product in productPrices)
    {
        order.Add(new LineItem(Guid.NewGuid(), order.Id, product.ProductId, product.Price));
    }

    // 4. Persist the order (details omitted for brevity)
    _orderRepository.Add(order);
    await _orderRepository.SaveChangesAsync();

    return Ok(new { OrderId = order.Id });
}

*/