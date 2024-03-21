using ECommerce.Domain.Abstractions;

namespace ECommerce.Domain.Entities
{
    public sealed class Customer: AuditableEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
