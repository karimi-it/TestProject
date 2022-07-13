using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace contactPresentation.Controllers
{

    [Route("[controller]/[action]")]
    public abstract class ApiControllerBase : Controller
    {


        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    }
}
