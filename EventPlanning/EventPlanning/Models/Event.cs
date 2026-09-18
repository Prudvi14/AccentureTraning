using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(25, ErrorMessage = "Event name cannot exceed 25 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event type is required.")]
        [StringLength(50, ErrorMessage = "Event type cannot exceed 50 characters.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Budget is required.")]
        public decimal Budget { get; set; }
    }
}