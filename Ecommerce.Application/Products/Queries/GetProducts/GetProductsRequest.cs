using ECommerce.Domain.Models;
using ECommerce.Domain.Shared;
using MediatR;

namespace ECommerce.Application.Products.Queries.GetProducts
{
    public record GetProductsRequest: IRequest<PaginatedList<ProductModel>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
