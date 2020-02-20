using Api.Core.Model.Data;
using Api.Core.Model.Repositories;
using Api.Data.Repositories;

namespace Api.Data.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public IProductRepository Product
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new ProductRepository();
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
                    userRepository = new UserRepository();
                }
                return userRepository;
            }
        }
    }
}
