using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;
using MyFirstApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. LIST all movies
        public IActionResult Index()
        {
            List<Movie> movies = _context.Movies.ToList();
            return View(movies);
        }

        // 2. SHOW create form (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. RECEIVE create form data (POST)
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index"); // go back to the list after saving
        }

        // 4. SHOW edit form with existing data (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Find(id); // find movie by Id
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // 5. RECEIVE edited data (POST)
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // 6. DELETE a movie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Movie movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie); // show confirmation page
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Movie movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}