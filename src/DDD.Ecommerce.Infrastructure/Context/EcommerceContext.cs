using DDD.Ecommerce.Domain.Invoices;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Infrastructure.Mappings;
using DDD.Ecommerce.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;


namespace DDD.Ecommerce.Infrastructure.Database.Context
{
    public class EcommerceContext : DbContext
    {
        public virtual DbSet<Order> Order => Set<Order>();
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Invoice> Invoices => Set<Invoice>();

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderLineMap());

            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new InvoiceLineMap());

            base.OnModelCreating(modelBuilder);

            ConfigureSeed(modelBuilder);
        }

        protected virtual void ConfigureSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(ProductSeed.CreateProducts());
        }
    }
}
