using DomainLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetSpecificProductAsync();
        Task<List<Product>> GetElectricProductAsync();
        Task<List<Product>> GetCategoryIdAsync(int id);

    }
}
