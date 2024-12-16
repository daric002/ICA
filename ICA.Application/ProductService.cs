using ICA.Core;

namespace ICA.Application;

public interface IProductService
{
    int AddProduct(Product product);
    Product? GetProductById(int id);
}

public class ProductService : IProductService
{
    private readonly IcaDbContext _context;

    public ProductService(IcaDbContext context)
    {
        _context = context;
    }

    public int AddProduct(Product product)
    {
        if (product.Price < 0) throw new ArgumentException("Can not have negative value on Price");
        if (product.Name == "") throw new ArgumentException("Name of product can not be empty");
        if (product.Name.Length > 100) throw new ArgumentException("Name is too long");

        _context.Add(product);
        return _context.SaveChanges();
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }
}
