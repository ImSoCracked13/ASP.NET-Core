using Microsoft.AspNetCore.Mvc;

namespace web1.Controllers
{
    //As default, Controller name is Subfolder name is Views
    //Action (method) name is View name
    /* For example:
     * StudentController => need to create new subfolder named "Student" in "Views"
     * Index() => need to create new view named "Index.cshtml" 
     */

    /* Controllers/StudentController.cs */
    public class StudentController : Controller
    {
        //url1: localhost:PORT/Student/Index
        //url2: localhost:PORT/Student
        public IActionResult Index()
        {
            //path: Views/Student/Index.cshtml
            return View();
        }

        //custom url: localhost:PORT/DanhSachSinhVien
        [Route("/DanhSachSinhVien")]
        public IActionResult List()
        {
            //custom view: Views/Demo/StudentList.cshtml
            return View("~/Views/Demo/StudentList.cshtml");
        }
    }
}
