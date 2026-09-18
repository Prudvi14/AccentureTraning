using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLifeHospital.Models
{
    public class PatientInfoDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationID { get; set; }

        [Required(ErrorMessage = "Patient Name is required.")]
        [StringLength(25, ErrorMessage = "Patient Name cannot exceed 25 characters.")]
        public string PatientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Blood Group is required.")]
        [StringLength(4, ErrorMessage = "Blood Group cannot exceed 4 characters.")]
        public string BloodGroup { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required.")]
        [StringLength(10, MinimumLength = 10,
            ErrorMessage = "Contact Number must contain exactly 10 digits.")]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "Contact Number must contain exactly 10 digits.")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email ID is required.")]
        [StringLength(30, ErrorMessage = "Email ID cannot exceed 30 characters.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string EmailID { get; set; } = string.Empty;
    }
}