using LHM.Models;
using LHM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHM.Controllers
{
    [Authorize]  
    public class PatientController : Controller
    {
        private readonly ILHMRepo _repo;

        public PatientController(ILHMRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            _repo.AddPatient(patient);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<Patient> patients = _repo.GetAllPatients();
            return View(patients);
        }

        public IActionResult Details(int id)
        {
            Patient patient = _repo.GetPatientById(id);
            if (patient == null) return NotFound();
            return View(patient);
        }
    }
}