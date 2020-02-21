using AmericaVirtual.Model.Repositories;

namespace AmericaVirtual.Data
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

        IUserRepository User { get; }

        IUserActionsRepository UserActions { get; }

        IUserPurchasesRepository UserPurchases { get; }
    }
}
