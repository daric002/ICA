using ICA.Core;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult CreateOrder(Order order)
    {
        try
        {
            var orderId = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = orderId }, orderId);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        Console.WriteLine($"Getting order {id}");
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
}