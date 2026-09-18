using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.DAL.Models
{
    public class ServiceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Details { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string RaisedBy { get; set; } = string.Empty;

        [Required]
        public DateTime RaisedOn { get; set; } = DateTime.Now;

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        public string Justification { get; set; } = string.Empty;

        public int ReqStatus { get; set; }

        [ForeignKey(nameof(ReqStatus))]
        public Status? Status { get; set; }
    }
}