using System.Collections.Generic;
using Api.Core.Model.Data;
using Api.Core.Model.Entities;
using Api.Core.Model.Repositories;
using Api.Data.DataAccess;

namespace Api.Data.Repositories
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

            };

            return parameters;
        }

        public override Dictionary<string, object> GetUpdateParams(User entity)
        {
            var parameters = new Dictionary<string, object>()
            {

            };

            return parameters;
        }

        public User GetUserInformationByEmail(string email)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@UserEmail", email }
            };

            return DbContext.GetSingleItem("", parameters, Mapper);
        }
    }
}
