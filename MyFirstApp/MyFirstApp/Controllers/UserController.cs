using Microsoft.AspNetCore.Mvc;
using UserDataLibrary.Models;
using UserDataLibrary.IRepo;

namespace MyFirstApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _userRepo;
        public UserController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _userRepo.AddUser(user);  // calling the repository method through the interface

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}