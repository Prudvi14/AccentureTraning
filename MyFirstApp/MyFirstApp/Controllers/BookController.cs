using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Details(int id)
        {
            List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 101,
                Title = "The Alchemist",
                Author = "Paulo Coelho",
                Price = 350,
                Pages = 208
            },
            new Book
            {
                Id = 102,
                Title = "Atomic Habits",
                Author = "James Clear",
                Price = 450,
                Pages = 320
            },
            new Book
            {
                Id = 103,
                Title = "1984",
                Author = "George Orwell",
                Price = 299,
                Pages = 328
            }
        };
            Book selectedBook = books.FirstOrDefault(b => b.Id == id);
            return View(selectedBook); 
        }
    }
}
