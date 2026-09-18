using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanningApp.Models;

[Table("Event")]
public class Event
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventId { get; set; }

    [Required(ErrorMessage = "Event Name is required.")]
    [StringLength(25, ErrorMessage = "Name length cannot exceed 25 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event Date is required.")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(100, ErrorMessage = "Location length cannot exceed 100 characters.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event Type is required.")]
    [StringLength(50, ErrorMessage = "Type length cannot exceed 50 characters.")]
    public string Type { get; set; } = string.Empty;

    [Required(ErrorMessage = "Budget is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Budget must be a valid positive number.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; }
}