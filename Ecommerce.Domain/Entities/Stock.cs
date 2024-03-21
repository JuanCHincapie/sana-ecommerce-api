using ECommerce.Domain.Abstractions;

namespace ECommerce.Domain.Entities
{
    public sealed class Stock : AuditableEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
