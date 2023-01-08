using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTO.Category;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryDTO>>(await _repository.GetAllAsync());
        }

        public async Task CreateAsync(CategoryDTO categoryDTO)
        {
            await _repository.CreateAsync(_mapper.Map<Category>(categoryDTO));
        }

        public async Task UpdateAsync(int id, CategoryDTO categoryDTO)
        {
            Category entity = await _repository.GetAsync(id);
            _mapper.Map(categoryDTO, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task<CategoryDTO> GetByNameAsync(string search)
        {
            Category model = await _repository.FindAsync(m => m.Name == search);
            return _mapper.Map<CategoryDTO>(model);
        }

        public async Task<List<CategoryDTO>> GetAllByConditionAsync(string search)
        {
            return _mapper.Map<List<CategoryDTO>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }

    }
}
