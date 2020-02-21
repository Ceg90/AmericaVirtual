using Api.Core.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.Core.Model.DTOs
{
    public class UserDto : BaseDto
    {
        public UserDto()
        {
        }

        public UserDto(User entity)
        {
            UserId = entity.UserId;
            Email = entity.Email;
            Password = entity.Password;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Address = entity.Address;
            PhoneNumber = entity.PhoneNumber;
        }
        [Required]
        public long UserId { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
