using Ecommerce.Domain.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Orders.Commands
{
    public class CreateOrderCommandValidation: AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation(ICustomerRepository customerRepository) 
        {
            RuleFor(x => x.CustomerId).MustAsync(async (customer, _) =>
            {
                return await customerRepository.Exists(customer);
            }).WithMessage("The customer does not exist.");

            RuleFor(x => x.OrderItems.Count).GreaterThan(0).WithMessage("Empty order.");
        }
    }
}
