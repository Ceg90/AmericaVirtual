using Api.Core.Model;
using Api.Core.Model.Data;

namespace Api.Core
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
