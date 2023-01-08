using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTO.Product;
using ServiceLayer.DTO.ProductImage;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ProductService :  IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            return _mapper.Map<List<ProductDTO>>(await _repository.GetProductsAsync());
        }
        public async Task<List<ProductDTO>> GetCategoryIdAsync(int id)
        {
            return _mapper.Map<List<ProductDTO>>(await _repository.GetCategoryIdAsync(id));
        }

        public async Task<List<ProductDTO>> GetSpecificAsync()
        {
            return _mapper.Map<List<ProductDTO>>(await _repository.GetSpecificProductAsync());
        }
        public async Task<List<ProductDTO>> GetElectricAsync()
        {
            return _mapper.Map<List<ProductDTO>>(await _repository.GetElectricProductAsync());
        }
        public async Task CreateAsync(ProductDTO productDTO)
        {
            
            ProductImageDTO productImage = new()
            {
                Image = productDTO.FormFile.FileName,
            };
            List<ProductImageDTO> productImageDTOs = new List<ProductImageDTO>();
            productImageDTOs.Add(productImage);
            productDTO.Images = productImageDTOs;
            await _repository.CreateAsync(_mapper.Map<Product>(productDTO));
        }

        public async Task UpdateAsync(int id, ProductDTO productDTO)
        {
            Product entity = await _repository.GetAsync(id);
            _mapper.Map(productDTO, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Product entity = await _repository.GetAsync(id);
            await _repository.SoftDeleteAsync(entity);
        }

        public async Task<ProductDTO> GetByNameAsync(string search)
        {
            Product model = await _repository.FindAsync(m => m.Name == search);
            return _mapper.Map<ProductDTO>(model);
        }

        public async Task<List<ProductDTO>> GetAllByConditionAsync(string search)
        {
            return _mapper.Map<List<ProductDTO>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }
    }
}
