using Application;
using Application.Contact.Commands;
using contactPresentation.Models;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MediatR;
namespace contactPresentation.Controllers
{
    public class HomeController : Controller
    {
        public readonly MyDbContext _db;
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>(); 
        private readonly ILogger<HomeController> _logger;
        public HomeController(MyDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
            _db.SaveChanges();
        }
 
        
        public  Task<GetContactResponse> GetContact( GetContactCommand command)
        {
            
            var x = Mediator.Send(command); ;
            return x;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}