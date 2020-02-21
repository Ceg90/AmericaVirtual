using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmericaVirtual.Model.Entities
{
    [Table("UserActions")]
    public class UserActions : BaseEntity
    {
        public UserActions()
        {
        }

        [Required]
        public int UserActionId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [StringLength(20)]
        public string Action { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
