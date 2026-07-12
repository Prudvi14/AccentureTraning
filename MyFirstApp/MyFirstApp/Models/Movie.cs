using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie name is required")]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Range(1900, 2010, ErrorMessage = "Enter a valid year")]
        public int ReleaseYear { get; set; }

        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
        public double Rating { get; set; }
    }
}