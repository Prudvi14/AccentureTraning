using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.DAL.Models
{
    public class User
    {
        [Key]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}