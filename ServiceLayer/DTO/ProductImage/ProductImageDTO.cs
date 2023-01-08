using ServiceLayer.DTO.Product;

namespace ServiceLayer.DTO.ProductImage
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public string Image { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductId { get; set; }
    }
}
