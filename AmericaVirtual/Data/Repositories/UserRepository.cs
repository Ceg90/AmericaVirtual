using AmericaVirtual.DataAccess;
using AmericaVirtual.Model.Entities;
using AmericaVirtual.Model.Repositories;
using System.Collections.Generic;

namespace AmericaVirtual.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISqlDataAccess dbContext, IMapper<User> mapper) : base(dbContext, mapper)
        {
        }

        public override Dictionary<string, object> GetInsertParams(User entity)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@Email", entity.Email},
                { "@Password", entity.Password},
                { "@FirstName", entity.FirstName},
                { "@LastName", entity.LastName},
                { "@Address", entity.Address},
                { "@PhoneNumber", entity.PhoneNumber}
            };

            return parameters;
        }

        public override Dictionary<string, object> GetUpdateParams(User entity)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@UserId", entity.UserId},
                { "@Email", entity.Email},
                { "@Password", entity.Password},
                { "@FirstName", entity.FirstName},
                { "@LastName", entity.LastName},
                { "@Address", entity.Address},
                { "@PhoneNumber", entity.PhoneNumber}
            };

            return parameters;
        }

        public User GetUserInformationByEmail(string email, string password)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@Email", email },
                { "@Password", password}
            };

            return DbContext.GetSingleItem("User_GetByEmail", parameters, Mapper);
        }
    }
}
