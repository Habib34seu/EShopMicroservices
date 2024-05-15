using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupones { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone X Description", Amount = 500 },
            new Coupon { Id = 2, ProductName = "Sumsung 10", Description = "Sumsung Description", Amount = 500 }
            );
    }

}
