using AmericaVirtual.Model.Entities;

namespace AmericaVirtual.Model.DTOs
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
        
        public int UserId { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}
