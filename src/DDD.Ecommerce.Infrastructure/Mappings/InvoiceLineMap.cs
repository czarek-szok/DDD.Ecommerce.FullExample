using DDD.Ecommerce.Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Ecommerce.Infrastructure.Mappings
{
    internal class InvoiceLineMap : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.NettPrice).IsRequired();
            builder.Property(x => x.GrossPrice).IsRequired();

            builder.OwnsOne(x => x.Tax, x =>
            {
                x.Property(x => x.Amount).IsRequired();
                x.Property(x => x.Description).IsRequired();
            });

            builder.HasOne(x => x.Product)
             .WithMany()
             .HasForeignKey("ProductId")
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
