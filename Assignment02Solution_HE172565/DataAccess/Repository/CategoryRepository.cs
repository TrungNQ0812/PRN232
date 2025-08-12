using BusinessObject;
using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<Category> AddAsync(CategoryDTO dto);
        Task UpdateAsync(int id, CategoryDTO dto);
        Task DeleteAsync(int id);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly eStoreDbContext _context;

        public CategoryRepository(eStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDTO
                {
                    CategoryName = c.CategoryName
                }).ToListAsync();
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) return null;

            return new CategoryDTO
            {
                CategoryName = c.CategoryName
            };
        }

        public async Task<Category> AddAsync(CategoryDTO dto)
        {
            var category = new Category
            {
                CategoryName = dto.CategoryName
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(int id, CategoryDTO dto)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) return;

            c.CategoryName = dto.CategoryName;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c == null) return;

            _context.Categories.Remove(c);
            await _context.SaveChangesAsync();
        }
    }
}
