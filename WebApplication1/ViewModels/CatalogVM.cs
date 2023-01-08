using ServiceLayer.DTO.Category;
using ServiceLayer.DTO.Product;
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public class CatalogVM
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
