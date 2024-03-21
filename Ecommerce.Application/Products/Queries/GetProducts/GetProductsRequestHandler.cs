using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Domain.Shared;
using MediatR;

namespace ECommerce.Application.Products.Queries.GetProducts
{
    public sealed class GetProductsRequestHandler(IProductRepository productRepository) : IRequestHandler<GetProductsRequest, PaginatedList<ProductModel>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<PaginatedList<ProductModel>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetPaginated(request.CurrentPage, request.PageSize, cancellationToken);
        }
    }
}
