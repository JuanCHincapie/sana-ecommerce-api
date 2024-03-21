using ECommerce.Domain.Models;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Shared;

namespace ECommerce.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> Add(Product product, CancellationToken cancellationToken = default);
        Task<bool> Delete(int productId, CancellationToken cancellationToken = default);
        Task<bool> Update(Product product, CancellationToken cancellationToken = default);
        Task<PaginatedList<ProductModel>> GetPaginated(int currentPage, int pageSize, CancellationToken cancellationToken = default);
    }
}
