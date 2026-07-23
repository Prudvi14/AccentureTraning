using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LHM.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Patient Name is required")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 20 characters")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [StringLength(35)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit contact number")]
        public string ContactNo { get; set; }

        [ValidateNever]
        public List<Appointment> Appointments { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}