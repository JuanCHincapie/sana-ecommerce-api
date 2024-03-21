using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infraestructure.Repositories
{
    public sealed class ProductRepository(IApplicationDbContext context) : IProductRepository
    {
        private readonly IApplicationDbContext _context = context;
        public async Task<PaginatedList<ProductModel>> GetPaginated(int currentPage, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Products.AsQueryable();
            var paginate = new PaginatedList<ProductModel>
            {
                CurrentPage = currentPage,
                PageSize = pageSize > 0 ? pageSize : 1,
                TotalRows = query.Count()
            };
            
            if (currentPage > 0 && pageSize > 0)
                query = query.Skip((paginate.CurrentPage - 1) * pageSize).Take(pageSize);

            paginate.Data = await query.Select(s => new ProductModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                AvailableStock = s.Stock.Quantity,
                Price = s.Price,
                CategoryId = s.CategoryId,
                CategoryName = s.Category.Name

            }).ToListAsync(cancellationToken);
            return paginate;
        }
        public async Task<bool> Add(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Add(product);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<bool> Delete(int productId, CancellationToken cancellationToken = default)
        {
            if (productId <= 0) return false;

            await _context.Products.Where(w => w.Id == productId).ExecuteDeleteAsync(cancellationToken);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<bool> Update(Product product, CancellationToken cancellationToken = default)
        {
            if (_context.Products.Any(a => a.Id == product.Id) == false) return false;

            await _context.Products.Where(w => w.Id == product.Id)
                .ExecuteUpdateAsync(set => set.SetProperty(m => m, product), cancellationToken);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
