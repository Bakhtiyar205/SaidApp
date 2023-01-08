using ServiceLayer.DTO.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllAsync();
        Task CreateAsync(CategoryDTO categoryDTO);
        Task UpdateAsync(int id, CategoryDTO categoryDTO);
        Task<CategoryDTO> GetByNameAsync(string search);
        Task<List<CategoryDTO>> GetAllByConditionAsync(string search);

    }
}
