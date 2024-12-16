
using ICA.Application;
using ICA.Core;

public interface IOrderService
{
    int CreateOrder(Order order);
    Order? GetOrderById(int id);
}

public class OrderService : IOrderService
{
    private readonly IProductService _productService;
    private readonly IcaDbContext _context;

    public OrderService(IcaDbContext context, IProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    public int CreateOrder(Order order)
    {
        if (order.Products.Count == 0) throw new ArgumentException("Must have at least one product in order");
        foreach (var product in order.Products)
        {
            var p = _productService.GetProductById(product.Id) ?? throw new ArgumentException($"Product {product.Id} not found.");
        }

        _context.Add(order);
        return _context.SaveChanges();
    }

    public Order? GetOrderById(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }
}