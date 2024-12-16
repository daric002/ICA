namespace ICA.Core;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public List<Product> Products { get; set; } = new();
    public decimal TotalPrice()
    {
        return Products.Sum(p => p.Price);
    }
}