using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infraestructure.Configurations
{
    internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem").HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.OrderId).IsRequired();
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasDefaultValue(0).HasColumnType("decimal").HasPrecision(18, 4);
            builder.Property(p => p.TotalPrice).IsRequired().HasDefaultValue(0).HasColumnType("decimal").HasPrecision(18, 4);
            builder.HasOne(m => m.Order).WithMany(m => m.OrderItems);
            builder.HasOne(m => m.Product).WithMany(m => m.OrderItems);
        }

    }
}
