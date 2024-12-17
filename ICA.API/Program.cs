using ICA.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<IcaDbContext>(options => options.UseInMemoryDatabase("TestDatabase"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IcaDbContext>();
    dbContext.Database.EnsureCreated();
}
app.MapControllers();

app.Run();