using ECommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Getategories.Queries
{
    public record GetCategoriesRequest: IRequest<List<Category>>
    {
    }
}
