using ICA.Application;
using ICA.Core;
using Microsoft.EntityFrameworkCore;

namespace ICA.Tests;

[TestClass]
public class OrderServiceTests
{
    private readonly IcaDbContext _context;
    private IProductService _productService;

    public OrderServiceTests()
    {
        var options = new DbContextOptionsBuilder<IcaDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;
        _context = new IcaDbContext(options);
        _context.Database.EnsureCreated();

        _productService = new ProductService(_context);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ShouldThrowWhenNoProducts()
    {
        //Arrange
        var orderService = new OrderService(_context, _productService);
        var order = new Order
        {
            Products = new List<Product>()
        };

        //Act
        orderService.CreateOrder(order);
    }

}