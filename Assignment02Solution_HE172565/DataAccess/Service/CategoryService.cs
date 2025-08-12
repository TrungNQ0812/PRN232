using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<Category> CreateAsync(CategoryDTO dto);
        Task UpdateAsync(int id, CategoryDTO dto);
        Task DeleteAsync(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<CategoryDTO>> GetAllAsync() => _repo.GetAllAsync();
        public Task<CategoryDTO?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Category> CreateAsync(CategoryDTO dto) => _repo.AddAsync(dto);
        public Task UpdateAsync(int id, CategoryDTO dto) => _repo.UpdateAsync(id, dto);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
