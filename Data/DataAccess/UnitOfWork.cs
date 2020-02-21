using Api.Core.Model.Data;
using Api.Core.Model.Entities;
using Api.Core.Model.Repositories;
using Api.Data.Repositories;

namespace Api.Data.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlDataAccess DbContext;

        private IProductRepository productRepository;
        private IUserRepository userRepository;

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
    }
}
