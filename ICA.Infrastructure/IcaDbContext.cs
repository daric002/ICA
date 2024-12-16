using ICA.Core;
using Microsoft.EntityFrameworkCore;

public class IcaDbContext : DbContext
{
    public IcaDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}