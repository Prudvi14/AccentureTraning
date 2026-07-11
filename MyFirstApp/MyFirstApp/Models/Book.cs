using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    //public class Book
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //    public decimal Price { get; set; }
    //    public int Pages { get; set; }
    //}

    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }

        [Range(1, 10000, ErrorMessage = "Pages must be a positive number")]
        public int Pages { get; set; }
    }
}
