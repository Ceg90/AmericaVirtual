using AmericaVirtual.Model.DTOs;

namespace AmericaVirtual.Model.Services
{
    public interface IUserService : IBaseService
    {
        long AddUser(UserDto user);

        UserDto GetUserInformationByEmail(string email, string password);

        void LogOut(int userId);
        
        void RemoveUser(int userId);

        int UserPurchase(int userId, int productId);

        void UpdateUser(UserDto user);
    }
}
