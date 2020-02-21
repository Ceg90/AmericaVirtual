using AmericaVirtual.Data;
using AmericaVirtual.Model.Entities;
using AmericaVirtual.Model.Repositories;
using AmericaVirtual.Data.Repositories;

namespace AmericaVirtual.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlDataAccess DbContext;

        private IProductRepository productRepository;
        private IUserRepository userRepository;
        private IUserActionsRepository userActionsRepository;
        private IUserPurchasesRepository userPurchasesRepository;

        public UnitOfWork(ISqlDataAccess dbContext)
        {
            DbContext = dbContext;
        }

        public IProductRepository Product
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new ProductRepository(DbContext, new Mapper<Product>());
                }
                return productRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(DbContext, new Mapper<User>());
                }
                return userRepository;
            }
        }

        public IUserActionsRepository UserActions
        {
            get
            {
                if(userActionsRepository == null)
                {
                    userActionsRepository = new UserActionsRepository(DbContext, new Mapper<UserActions>());
                }
                return userActionsRepository;
            }
        }

        public IUserPurchasesRepository UserPurchases
        {
            get
            {
                if (userPurchasesRepository == null)
                {
                    userPurchasesRepository = new UserPurchasesRepository(DbContext, new Mapper<UserPurchases>());
                }
                return userPurchasesRepository;
            }
        }
    }
}
