using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class ProductImage : BaseEntity
    {
        public string Image { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
