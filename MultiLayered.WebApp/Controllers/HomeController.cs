using Microsoft.AspNetCore.Mvc;
using MultiLayered.Core.Dtos;
using System.Diagnostics;

namespace MultiLayered.WebApp.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        //düzenledik
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error(ErrorViewModel errorViewModel)
            {
              return View(errorViewModel);
            }
    }
}
