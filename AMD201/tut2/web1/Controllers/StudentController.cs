using Microsoft.AspNetCore.Mvc;
using web1.Models;

namespace web1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentDetail()
        {
            //create an object for "Student" class
            Student student = new Student
            {
                Name = "Student Demo",
                Email = "demo@fpt.edu.vn",
                Gender = "Male",
                GPA = 7.8
            };

            Student student1 = new Student();
            student1.Name = "Student 1";
            student1.Gender = "Female";
            student1.GPA = 9.9;
            student1.Email = "s1@gmail.com";

            //render view and pass data as model
            return View(student1);
        }


        public IActionResult StudentList() {
            List<Student> students = new List<Student>();

            Student student1 = new Student();
            student1.Name = "Student 1";
            student1.Gender = "Female";
            student1.GPA = 9.9;
            student1.Email = "s1@gmail.com";

            Student student2 = new Student
            {
                Name = "Student 2",
                Email = "s2@fpt.edu.vn",
                Gender = "Male",
                GPA = 7.8
            };

            Student student3 = new Student
            {
                Name = "Student 3",
                Email = "s3@fpt.edu.vn",
                Gender = "Male",
                GPA = 6.8
            };

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            return View(students);
        }
    }
}
