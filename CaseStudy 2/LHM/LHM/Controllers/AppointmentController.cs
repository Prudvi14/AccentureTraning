using LHM.Models;
using LHM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHM.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ILHMRepo _repo;

        public AppointmentController(ILHMRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            _repo.AddAppointment(appointment);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<Appointment> appointments = _repo.GetAllAppointments();
            return View(appointments);
        }
    }
}