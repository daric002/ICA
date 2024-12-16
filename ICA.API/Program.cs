using ICA.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IcaDbContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

app.Run();