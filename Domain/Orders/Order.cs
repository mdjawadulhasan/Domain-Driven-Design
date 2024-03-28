using Domain.Customers;
using Domain.Products;
namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _items = new();
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }

    public static Order Create(Customer customer)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
        };
        return order;
    }

    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);
        _items.Add(lineItem);
    }
}

public class LineItem
{
    public LineItem(Guid id, Guid orderId, Guid productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public Money Price { get; private set; }
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