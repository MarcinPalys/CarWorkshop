using System.Diagnostics;
using CarWorkshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var model = new List<Person>()
            {
                new Person() 
                {
                    FirstName = "Adam",
                    LastName = "Nowak"                    
                },
                new Person()
                {
                    FirstName = "Jakub",
                    LastName = "Kowalski"
                }
            };
            return View(model);
        }

        public IActionResult About()
        {
            var Movies = new List<Details>()
            {
                new Details()
                {
                    Title = "W³adca pierœcieni",
                    Description = "Fajny film",
                    Tags = new[] { "trylogia", "film wojenny"}
                },
                new Details()
                {
                    Title = "Gladiator",
                    Description = "Czêœæ pierwsza",
                    Tags = new[] { "rzym", "walki gladiatorów"}
                },
            };
            return View(Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
