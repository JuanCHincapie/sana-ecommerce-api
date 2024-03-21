using Ecommerce.Domain.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Getategories.Queries
{
    public sealed class GetCategoriesRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesRequest, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        public async Task<List<Category>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll(cancellationToken);
        }
    }
}
