using DDD.Ecommerce.Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DDD.Ecommerce.Infrastructure.Mappings
{
    internal class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NettPrice).IsRequired();
            builder.Property(x => x.GrossPrice).IsRequired();

            builder.HasMany(x => x.Lines)
                .WithOne()
                .HasForeignKey("InvoiceId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
