using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Janglee.Models.DTO
{
    [Table("User")]
    public partial class User
    {
        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }

        [StringLength(20)]
        public string Role { get; set; }
    }
}
