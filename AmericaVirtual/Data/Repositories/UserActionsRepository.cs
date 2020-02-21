using AmericaVirtual.DataAccess;
using AmericaVirtual.Model.Entities;
using AmericaVirtual.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AmericaVirtual.Data.Repositories
{
    public class UserActionsRepository : Repository<UserActions>, IUserActionsRepository
    {
        public UserActionsRepository(ISqlDataAccess dbContext, IMapper<UserActions> mapper) : base(dbContext, mapper)
        {
        }

        public override Dictionary<string, object> GetInsertParams(UserActions entity)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@UserId", entity.UserId},
                { "@Action", entity.Action},
                { "@Date", entity.Date}
            };

            return parameters;
        }

        public override Dictionary<string, object> GetUpdateParams(UserActions entity)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@UserActionId", entity.UserActionId},
                { "@UserId", entity.UserId},
                { "@Action", entity.Action},
                { "@Date", entity.Date}
            };

            return parameters;
        }


    }
}