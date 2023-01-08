using ServiceLayer.DTO.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task CreateAsync(ProductDTO categoryDTO);
        Task UpdateAsync(int id, ProductDTO categoryDTO);
        Task<ProductDTO> GetByNameAsync(string search);
        Task<List<ProductDTO>> GetAllByConditionAsync(string search);
        Task<List<ProductDTO>> GetSpecificAsync();
        Task<List<ProductDTO>> GetElectricAsync();
        Task<List<ProductDTO>> GetCategoryIdAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
