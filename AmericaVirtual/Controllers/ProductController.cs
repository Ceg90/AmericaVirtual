using AmericaVirtual.Model.DTOs;
using AmericaVirtual.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AmericaVirtual.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService productService)
        {
            service = productService;
        }

        [HttpPost]
        public ActionResult<long> AddUser([FromBody] ProductDto product)
        {
            return Ok(service.AddProduct(product));
        }

        [HttpGet]
        [Route("GetPaginatedProducts")]
        public ActionResult<PageResult<ProductDto>> GetPaginatedResult(int currentPage, int pageSize, string sortBy, SortOrder sortOrder)
        {
            return Ok(service.GetPaginatedProducts(currentPage, pageSize, sortBy, sortOrder));
        }

        [HttpGet]
        [Route("{productId:long}")]
        public ActionResult<ProductDto> GetProductById(long productId)
        {
            return Ok(service.GetProductById(productId));
        }

        [HttpDelete]
        public IActionResult RemoveProduct(long productId)
        {
            service.RemoveProduct(productId);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto product)
        {
            service.UpdateProduct(product);
            return Ok();
        }
    }
}