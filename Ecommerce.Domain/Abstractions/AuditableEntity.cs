namespace ECommerce.Domain.Abstractions
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
