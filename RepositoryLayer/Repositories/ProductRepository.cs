using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
          return  await _context.Set<Product>()
                          .Where(m => !m.IsDelete)
                          .Include(m=>m.Images)
                          .Include(m=>m.Category)
                          .ToListAsync();
        }
        public async Task<List<Product>> GetCategoryIdAsync(int id)
        {
            int number = 0;
            return await _context.Set<Product>()
                            .Where(m => !m.IsDelete && m.CategoryId == id)
                            .Include(m => m.Images)
                            .Include(m => m.Category)
                            .ToListAsync();
        }
        public async Task<List<Product>> GetSpecificProductAsync()
        {
            int number = 0;
            return await _context.Set<Product>()
                            .Where(m => !m.IsDelete && m.CategoryId == 1)
                            .Include(m => m.Images)
                            .Include(m => m.Category)
                            .ToListAsync();
        }
        public async Task<List<Product>> GetElectricProductAsync()
        {
            int number = 0;
            return await _context.Set<Product>()
                            .Where(m => !m.IsDelete && m.CategoryId == 2)
                            .Include(m => m.Images)
                            .Include(m => m.Category)
                            .ToListAsync();
        }
    }
}
