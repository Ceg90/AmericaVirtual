using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmericaVirtual.Model.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(15)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public string Images { get; set; }
    }
}
