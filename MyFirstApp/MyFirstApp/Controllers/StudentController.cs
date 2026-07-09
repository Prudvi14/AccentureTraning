using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Details()
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Prudvi",
                Course = "ASP.NET Core"
            };
            return View(student);
        }
    }
}
