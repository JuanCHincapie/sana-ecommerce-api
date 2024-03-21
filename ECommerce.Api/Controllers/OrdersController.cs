using Ecommerce.Application.Orders.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Api.Controllers
{
    public sealed class OrdersController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command, CancellationToken cancellationToken)
            => Ok(await Sender.Send(command, cancellationToken));

    }
}
