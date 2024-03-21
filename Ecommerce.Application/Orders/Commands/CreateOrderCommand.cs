using Ecommerce.Domain.Shared;
using ECommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Orders.Commands
{
    public record CreateOrderCommand: IRequest<Response<bool>>
    {
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
