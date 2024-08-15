using Microsoft.AspNetCore.Mvc;
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

        //url: localhost:PORT/Home/Demo
        public IActionResult Demo()
        {
            //location: Views/Home/Demo.cshtml
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

        public IActionResult Test()
        {
            int number = 10;
            //1. pass data by ViewBag
            ViewBag.Number = number;
            ViewBag.Text = "Greenwich";

            //2. pass data by ViewData
            ViewData["Sports"] = "Football";

            //3. pass data by TempData
            TempData["Info"] = "Add data succeed !";

            return View();
        }
    }
}
