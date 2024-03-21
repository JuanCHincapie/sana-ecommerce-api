using ECommerce.Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public sealed class ProductsController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
            => Ok(await Sender.Send(request, cancellationToken));
    }
}
