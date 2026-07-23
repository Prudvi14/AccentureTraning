using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LHM.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Patient ID is required")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Appointment Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        
        [ValidateNever]
        public Patient Patient { get; set; }
    }
}