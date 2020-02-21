using Api.Core.Model.DTOs;

namespace Api.Core.Model.Services
{
    public interface IUserService : IBaseService
    {
        long AddUser(UserDto user);

        UserDto GetUserInformationByEmail(string email);
        
        void RemoveUser(long userId);

        void UpdateUser(UserDto user);
    }
}
