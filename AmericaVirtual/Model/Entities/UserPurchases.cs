using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmericaVirtual.Model.Entities
{
    [Table("UserPurchases")]
    public class UserPurchases : BaseEntity
    {
        public UserPurchases()
        {
        }

        [Required]
        public int UserPurchasesId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
