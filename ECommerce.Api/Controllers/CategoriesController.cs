using Ecommerce.Application.Getategories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public sealed class CategoriesController: ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await Sender.Send(new GetCategoriesRequest()));
    }
}
