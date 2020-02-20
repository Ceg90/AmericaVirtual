using Api.Core.Model.Repositories;

namespace Api.Core.Model.Data
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
    }
}
