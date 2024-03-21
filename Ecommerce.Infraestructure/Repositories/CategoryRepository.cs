using Ecommerce.Domain.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infraestructure.Repositories
{
    public sealed class CategoryRepository(IApplicationDbContext context): ICategoryRepository
    {
        private readonly IApplicationDbContext _context = context;
        public async Task<List<Category>> GetAll(CancellationToken cancellationToken = default)
            => await _context.Categories.ToListAsync(cancellationToken);
    }
}
