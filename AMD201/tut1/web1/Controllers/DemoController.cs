using Microsoft.AspNetCore.Mvc;

namespace web1.Controllers
{
    //Controller : Backend side (BE)
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            //data passing from BE to FE
            //model binding

            //method 1: use ViewBag
            ViewBag.Text = "Today is Monday";
            ViewBag.Number = 2024;
            ViewBag.Today = DateTime.Now.ToString();

            //method 2: use ViewData
            ViewData["Name"] = "David Beckham";
            ViewData["ModuleCode"] = "AMD201";

            return View();
        }
    }
}
