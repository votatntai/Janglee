using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Janglee.Models.DTO
{
    [Table("Product")]
    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public double? Price { get; set; }

        public int? Quantity { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
    }
}
