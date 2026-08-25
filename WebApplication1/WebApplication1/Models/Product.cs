using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopCart.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1,000,000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Made nullable — the user doesn't type this directly, 
        // the controller sets it after saving the uploaded file
        public string? ImagePath { get; set; }

        public DateTime CreateAt { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}