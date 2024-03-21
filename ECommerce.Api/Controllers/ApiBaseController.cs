using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
        protected ISender _sender;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
