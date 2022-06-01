using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Category;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task AddAsync(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            return _categoryRepository.AddAsync(category);
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var result = await _categoryRepository.GetAll()
                .Include(w => w.Wares)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<CategoryDto>>(result) : new List<CategoryDto>();
        }

        public async Task<CategoryDto> GetCategoryByName(string name)
        {
            var result = await _categoryRepository.GetAll().Where(x => x.Title == name).ToListAsync();
            return result.Count > 0 ? _mapper.Map<CategoryDto>(result[0]) : new CategoryDto();
        }

        public async Task RemoveAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception($"Не найдена категория с id: {id}");
            }
            await _categoryRepository.RemoveAsync(category);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }
    }

}
