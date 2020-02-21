using AmericaVirtual.Model.Entities;

namespace AmericaVirtual.Model.DTOs
{
    public class ProductDto : BaseDto
    {
        public int MyProperty { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(Product entity)
        {
            ProductId = entity.ProductId;
            Title = entity.Title;
            Description = entity.Description;
            Price = entity.Price;
            Images = entity.Images;
        }
        
        public int ProductId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }

        public string Images { get; set; }
    }
}
