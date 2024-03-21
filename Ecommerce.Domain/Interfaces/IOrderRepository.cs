using Ecommerce.Domain.Shared;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Response<bool>> Add(Order order, CancellationToken cancellationToken = default);
        Task<Order?> Get(int orderId, CancellationToken cancellationToken = default);
        Task<bool> DeleteItem(int orderId, int orderItemId, CancellationToken cancellationToken = default);
    }
}
