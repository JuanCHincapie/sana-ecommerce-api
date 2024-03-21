namespace Ecommerce.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> Exists(int customerId, CancellationToken cancellationToken = default);
    }
}
