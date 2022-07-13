using Application.Contact.Commands;
using Microsoft.AspNetCore.Mvc;

namespace contact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ApiControllerBase
    {
  

        private readonly ILogger<WeatherForecastController> _logger;

        public ContactController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetContact")] 
        public async Task<GetContactResponse> GetContact([FromBody] GetContactCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}