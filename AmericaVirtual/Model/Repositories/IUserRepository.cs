using AmericaVirtual.Data;
using AmericaVirtual.Model.Entities;

namespace AmericaVirtual.Model.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserInformationByEmail(string email, string password);
    }
}
