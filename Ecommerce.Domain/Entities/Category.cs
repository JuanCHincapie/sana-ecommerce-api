using ECommerce.Domain.Abstractions;

namespace ECommerce.Domain.Entities
{
    public sealed class Category: AuditableEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
