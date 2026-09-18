using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EventPlanningApp.Models;
using EventPlanningApp.Repositories;

namespace EventPlanningApp.Controllers;

public class EventController : Controller
{
    private readonly IRepository _repository;

    public EventController(IRepository repository)
    {
        _repository = repository;
    }

    // GET: /Event/GetEventList
    [HttpGet]
    public IActionResult GetEventList(string? searchTerm)
    {
        try
        {
            var events = _repository.ViewAllEvents();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                events = events.Where(e =>
                    e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    e.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    e.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            ViewBag.SearchTerm = searchTerm;
            return View(events);
        }
        catch (Exception ex)
        {
            return Content("Error loading events: " + ex.Message);
        }
    }

    // GET: /Event/CreateEvent
    [HttpGet]
    public IActionResult CreateEvent()
    {
        return View();
    }

    // POST: /Event/CreateEvent
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateEvent(Event events)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool isCreated = _repository.CreateEvent(events);
                if (isCreated)
                {
                    return RedirectToAction(nameof(GetEventList));
                }
                ModelState.AddModelError("", "Failed to save event to database.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error: " + ex.Message);
        }

        return View(events);
    }

    // GET: /Event/EditEvent/5
    [HttpGet]
    public IActionResult EditEvent(int id)
    {
        try
        {
            var item = _repository.ViewEventById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        catch (Exception ex)
        {
            return Content("Error retrieving event: " + ex.Message);
        }
    }

    // POST: /Event/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Event events)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _repository.UpdateEvent(events);
                if (isUpdated)
                {
                    return RedirectToAction(nameof(GetEventList));
                }
                ModelState.AddModelError("", "Failed to update record in database.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error: " + ex.Message);
        }

        return View("EditEvent", events);
    }
}