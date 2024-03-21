using ECommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll(CancellationToken cancellationToken = default);
    }
}
