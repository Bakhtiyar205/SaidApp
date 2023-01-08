using ServiceLayer.DTO.Product;
using System.Collections.Generic;

namespace ServiceLayer.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
