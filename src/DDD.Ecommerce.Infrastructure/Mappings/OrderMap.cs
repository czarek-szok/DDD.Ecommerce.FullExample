using DDD.Ecommerce.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDD.Ecommerce.Infrastructure.Mappings
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired().HasConversion(new EnumToStringConverter<OrderStatus>());
            builder.Property(x => x.AcceptDate).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();

            builder.HasMany(x => x.OrderLines)
                .WithOne()
                .HasForeignKey("OrderId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Customer).WithMany().HasForeignKey("CustomerId").IsRequired();
        }
    }
}
