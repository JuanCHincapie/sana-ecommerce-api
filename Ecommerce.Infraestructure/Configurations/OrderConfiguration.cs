using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infraestructure.Configurations
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.OrderStatus).IsRequired();
            builder.Property(p => p.TotalPrice).IsRequired().HasColumnType("decimal").HasPrecision(18, 4);
            builder.Property(p => p.Observations).HasMaxLength(200);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.HasOne(m => m.Customer).WithMany(m => m.Orders);
        }
    }
}
