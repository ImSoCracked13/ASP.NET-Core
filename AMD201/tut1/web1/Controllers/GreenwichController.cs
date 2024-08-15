using Microsoft.AspNetCore.Mvc;

namespace web1.Controllers
{
    public class GreenwichController : Controller
    {
        //localhost:PORT/Greenwich
        public IActionResult Index()
        {
            //Views/Greenwich/Index.cshtml
            return View();
        }

        //localhost:PORT/Greenwich/Hanoi
        public IActionResult HaNoi()
        {
            //Views/Greenwich/Hanoi.cshtml
            return View();
        }

        public IActionResult HCM()
        {
            return View();
        }

        public IActionResult DaNang()
        {
            return View();
        }

        public IActionResult CanTho()
        {
            return View();
        }
    }
}
