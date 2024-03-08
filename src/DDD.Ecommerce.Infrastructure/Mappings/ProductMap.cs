using DDD.Ecommerce.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace DDD.Ecommerce.Infrastructure.Mappings
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Type).HasConversion(new EnumToStringConverter<ProductType>());
        }
    }
}
