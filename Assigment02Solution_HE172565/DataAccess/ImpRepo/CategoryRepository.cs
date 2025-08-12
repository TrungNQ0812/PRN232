using BusinessObject.Models;
using DataAccess.DAOs;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImpRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO categoryDAO;

        public CategoryRepository(CategoryDAO _categoryDAO)
        {
            categoryDAO = _categoryDAO;
        }

        public List<Category> GetAll() => categoryDAO.GetCategories();

        public Category GetById(int id) => categoryDAO.GetCategoryById(id);

        public void Add(Category category) => categoryDAO.AddCategory(category);

        public void Update(Category category) => categoryDAO.UpdateCategory(category);

        public void Delete(int id) => categoryDAO.DeleteCategory(id);
    }
}
