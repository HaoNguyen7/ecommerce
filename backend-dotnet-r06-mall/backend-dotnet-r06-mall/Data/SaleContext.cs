using backend_dotnet_r06_mall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace backend_dotnet_r06_mall.Data
{
    public class SaleContext : IdentityDbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {

        }

        public DbSet<Store>? Stores { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<PaymentType>? PaymentTypes { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<OrderStatus>? OrderStatuses { get; set; }

        public DbSet<OrderProduct>? OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany(p => p.Product)
            .WithMany(p => p.Order)
            .UsingEntity<OrderProduct>(
                j => j
                .HasOne(p => p.Product)
                .WithMany(t => t.OrderProduct)
                .HasForeignKey(pt => pt.ProductId),

                j => j
                .HasOne(pt => pt.Order)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(pt => pt.OrderId),

                j =>
                {
                    j.HasKey(t => new { t.OrderId, t.ProductId });
                }

            );
            base.OnModelCreating(modelBuilder);
        }

    }
}