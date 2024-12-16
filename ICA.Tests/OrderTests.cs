using System.Security;
using ICA.Core;

namespace ICA.Tests;

[TestClass]
public class OrderTests
{
    [TestMethod]
    public void ShouldReturnCorrectTotalPrice()
    {
        List<int> prices = [1, 2];
        var order = new Order
        {
            Products = [new Product { Price = prices[0] }, new Product { Price = prices[1] }]
        };
        Assert.AreEqual(prices.Sum(), order.TotalPrice());
    }
}