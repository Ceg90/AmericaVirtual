using System.Collections.Generic;
using AmericaVirtual.DataAccess;
using AmericaVirtual.Model.Entities;
using AmericaVirtual.Model.Repositories;

namespace AmericaVirtual.Data.Repositories
{
    public class UserPurchasesRepository : Repository<UserPurchases>, IUserPurchasesRepository
    {
        public UserPurchasesRepository(ISqlDataAccess dbContext, IMapper<UserPurchases> mapper) : base(dbContext, mapper)
        {
        }

        public override Dictionary<string, object> GetInsertParams(UserPurchases entity)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@UserId", entity.UserId},
                { "@ProductId", entity.ProductId}
            };

            return parameters;
        }

        public override Dictionary<string, object> GetUpdateParams(UserPurchases entity)
        {
            var parameters = new Dictionary<string, object>()
            {   { "@UserPurchasesId", entity.UserPurchasesId},
                { "@UserId", entity.UserId},
                { "@ProductId", entity.ProductId}
            };

            return parameters;
        }
    }
}