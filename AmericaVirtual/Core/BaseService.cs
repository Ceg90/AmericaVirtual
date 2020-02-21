using AmericaVirtual.Model;
using AmericaVirtual.Data;

namespace AmericaVirtual.Core
{
    public abstract class BaseService : IBaseService
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
