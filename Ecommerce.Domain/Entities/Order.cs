using ECommerce.Domain.Abstractions;

namespace ECommerce.Domain.Entities
{
    public sealed class Order: AuditableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatus { get; set; }
        public string? Observations { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
