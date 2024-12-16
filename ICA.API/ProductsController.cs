using ICA.Application;
using ICA.Core;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        try
        {
            _productService.AddProduct(product);
            return Created();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex);
        }
    }
}