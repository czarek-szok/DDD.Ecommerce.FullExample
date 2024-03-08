using DDD.Ecommerce.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace DDD.Ecommerce.Infrastructure.Mappings
{
    internal class OrderLineMap : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.TotalPriceWithDiscount).IsRequired();
       

            builder.HasOne(x => x.Product)
             .WithMany()
             .HasForeignKey("ProductId")
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
