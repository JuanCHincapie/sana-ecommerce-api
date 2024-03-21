using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infraestructure.Configurations
{
    internal sealed class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock").HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.ProductId).IsRequired();
            builder.HasOne(m => m.Product).WithOne(w => w.Stock);
        }
    }
}
