using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Core.Model.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required]
        public long ProductId { get; set; }

        [Required]
        [StringLength(15)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Images { get; set; }
    }
}
