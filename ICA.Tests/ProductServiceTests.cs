using System.Security;
using ICA.Application;
using ICA.Core;
using Microsoft.EntityFrameworkCore;

namespace ICA.Tests;

[TestClass]
public class ProductServiceTests
{
    private readonly IcaDbContext _context;

    public ProductServiceTests()
    {
        var options = new DbContextOptionsBuilder<IcaDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;
        _context = new IcaDbContext(options);
        _context.Database.EnsureCreated();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ShouldThrowWhenNegativePrice()
    {
        //Arrange
        var orderService = new ProductService(_context);
        var product = new Product
        {
            Price = -5
        };

        //Act
        orderService.AddProduct(product);
    }
}