using Ecommerce.Domain.Shared;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Orders.Commands
{
    internal sealed class CreateOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, Response<bool>>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        public async Task<Response<bool>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new() { 
                CustomerId = request.CustomerId, 
                TotalPrice = request.OrderItems.Sum(s => s.TotalPrice),
                OrderItems = request.OrderItems.Select(s => new OrderItem { Price = s.Price, Quantity = s.Quantity, ProductId = s.ProductId, TotalPrice = s.TotalPrice }).ToList()
            };
            return await _orderRepository.Add(order, cancellationToken);
        }
    }
}
