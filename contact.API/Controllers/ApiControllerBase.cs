﻿using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace contact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ApiControllerBase : ControllerBase
    {


        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    }
}

