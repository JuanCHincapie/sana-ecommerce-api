using Ecommerce.Domain.Shared;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ECommerce.Infraestructure.Repositories
{
    internal sealed class OrderRepository(IApplicationDbContext context) : IOrderRepository
    {
        public readonly IApplicationDbContext _context = context;
        public async Task<Response<bool>> Add(Order order, CancellationToken cancellationToken = default)
        {
            if (order == null) return Response<bool>.Failure("Failed to generate the order.");

            string message = "";
            using (TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                var available = _context.Stocks
                    .Include(m => m.Product)
                    .Where(w => order.OrderItems.Select(s => s.ProductId).Contains(w.ProductId))
                    .ToList();

                foreach (var item in order.OrderItems) 
                {
                    var availableProduct = available.FirstOrDefault(w => w.ProductId == item.ProductId);
                    if (availableProduct?.Quantity >= item.Quantity)
                    {
                        availableProduct.Quantity -= item.Quantity;
                        _context.Stocks.Update(availableProduct);
                    }
                    else
                    {
                        message += $"Insufficient stock in item {item.ProductId}-{availableProduct?.Product?.Name}\n";
                    }
                }

                if(!string.IsNullOrEmpty(message)) return Response<bool>.Failure(message);

                _context.Orders.Add(order);
                bool saved = (await _context.SaveChangesAsync(cancellationToken)) > 0;

                if (saved)
                {
                    transaction.Complete();
                    return Response<bool>.Success(true);
                }
                else return Response<bool>.Failure("Failed to generate the order.");
            }
        }

        public async Task<bool> DeleteItem(int orderId, int orderItemId, CancellationToken cancellationToken = default)
        {
            var orderItem = await _context.OrderItems.Where(w => w.OrderId == orderId && w.Id == orderItemId)
                .FirstOrDefaultAsync(cancellationToken);
            if (orderItem == null) return false;

            _context.OrderItems.Remove(orderItem);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<Order?> Get(int orderId, CancellationToken cancellationToken = default) 
            => await _context.Orders.FirstOrDefaultAsync(f => f.Id == orderId, cancellationToken);
    }
}
