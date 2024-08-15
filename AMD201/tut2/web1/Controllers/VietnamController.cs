using Microsoft.AspNetCore.Mvc;

namespace web1.Controllers
{
    public class VietnamController : Controller
    {
        //localhost:PORT/Vietnam/Hanoi
        public IActionResult Hanoi()
        {
            //Views/Vietnam/Hanoi.cshtml
            return View();
        }

        //default url:  localhost:PORT/Vietnam/HCMCity
        //set custom url
        [Route("/SaiGon")]
        public IActionResult HCMCity()
        {
            //default view location: Views/Vietnam/HCMCity.cshtml
            //set custom view: Views/Home/SaiGon.cshtml
            return View("~/Views/Home/SaiGon.cshtml");
        }
    }
}
