using AmericaVirtual.Data;
using AmericaVirtual.Model.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AmericaVirtual.Model.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetPaginatedProduct(int currentPage, int pageSize, string sortBy, SortOrder sortOrder);
    }
}
