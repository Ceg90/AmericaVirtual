using Api.Core.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Api.Core.Model.Services
{
    public interface IProductService : IBaseService
    {
        long AddProduct(ProductDto product);

        PageResult<ProductDto> GetPaginatedProducts(int currentPage, int pageSize, string sortBy, SortOrder sortOrder);

        ProductDto GetProductById(long productId);

        void RemoveProduct(long productId);

        void UpdateProduct(ProductDto product);
    }
}
