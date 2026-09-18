using Microsoft.AspNetCore.Mvc;
using NewLifeHospital.DataAccess;
using NewLifeHospital.Models;

namespace NewLifeHospital.Controllers
{
    public class PatientInfoController : Controller
    {
        private readonly IRepository _repository;

        public PatientInfoController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: /PatientInfo/RegisterForMembership
        [HttpGet]
        public ActionResult RegisterForMembership()
        {
            return View();
        }

        // POST: /PatientInfo/RegisterForMembership
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterForMembership(PatientInfoDetail pObj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pObj);
                }

                bool result = _repository.RegisterForMembership(pObj);

                if (result)
                {
                    TempData["SuccessMessage"] =
                        "Patient registered successfully.";

                    return RedirectToAction(nameof(RegisterForMembership));
                }

                TempData["ErrorMessage"] =
                    "Unable to register patient.";

                return View(pObj);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] =
                    "An error occurred while registering the patient.";

                return View(pObj);
            }
        }

        // GET: /PatientInfo/CancelMembership
        [HttpGet]
        public ActionResult CancelMembership()
        {
            return View();
        }

        // POST: /PatientInfo/CancelMembership
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelMembership(int registrationId)
        {
            try
            {
                if (registrationId <= 0)
                {
                    ViewBag.Message =
                        "Please enter a valid Registration ID.";

                    return View();
                }

                bool result =
                    _repository.CancelMembership(registrationId);

                if (result)
                {
                    TempData["SuccessMessage"] =
                        "Membership cancelled successfully.";

                    return RedirectToAction(nameof(CancelMembership));
                }

                ViewBag.Message =
                    "No patient found for the specified Registration ID.";

                return View();
            }
            catch (Exception)
            {
                ViewBag.Message =
                    "An error occurred while cancelling membership.";

                return View();
            }
        }

        // GET: /PatientInfo/UpdateEmail
        [HttpGet]
        public ActionResult UpdateEmail()
        {
            return View();
        }

        // POST: /PatientInfo/UpdateEmail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmail(int registrationId, string email)
        {
            try
            {
                if (registrationId <= 0)
                {
                    ViewBag.Message =
                        "Please enter a valid Registration ID.";

                    return View();
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    ViewBag.Message =
                        "Email ID is required.";

                    return View();
                }

                if (!new System.ComponentModel.DataAnnotations
                    .EmailAddressAttribute()
                    .IsValid(email))
                {
                    ViewBag.Message =
                        "Please enter a valid Email ID.";

                    return View();
                }

                bool result =
                    _repository.UpdateEmail(
                        registrationId,
                        email);

                if (result)
                {
                    TempData["SuccessMessage"] =
                        "Email ID updated successfully.";

                    return RedirectToAction(nameof(UpdateEmail));
                }

                ViewBag.Message =
                    "No patient found for the specified Registration ID.";

                return View();
            }
            catch (Exception)
            {
                ViewBag.Message =
                    "An error occurred while updating the Email ID.";

                return View();
            }
        }
    }
}