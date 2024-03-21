using Ecommerce.Domain.Interfaces;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infraestructure.Repositories
{
    public sealed class CustomerRepository(IApplicationDbContext context) : ICustomerRepository
    {
        private readonly IApplicationDbContext _context = context;
        public async Task<bool> Exists(int customerId, CancellationToken cancellationToken = default) 
            => await _context.Customers.AnyAsync(a => a.Id == customerId, cancellationToken);
    }
}
