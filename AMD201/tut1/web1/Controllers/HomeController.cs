using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Diagnostics;
using web1.Models;

namespace web1.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Web url: localhost:PORT/Home/Greenwich
        public IActionResult Greenwich()
        {
            //View location: Views/Home/Greenwich.cshtml
            return View();
        }

        //Web url: localhost:PORT/Home/FPT
        public IActionResult FPT()
        {
            //View location: Views/Home/FPT.cshtml
            return View();
        }
    }
}
