using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		public Task<IEnumerable<T>> GetAllAsync();
		public Task<T?>GetByIdAsync(object id);
		Task AddAsync(T entity);
		public void UpdateAsync(T entity);
		public void DeleteAsync(T entity);
		Task SaveAsync();
		public IQueryable<T> Query();
	}

	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly eStoreDbContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(eStoreDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void DeleteAsync(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T?> GetByIdAsync(object id)
		{
			return await _dbSet.FindAsync(id);
		}

		public IQueryable<T> Query()
		{
			return _dbSet.AsQueryable();
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}
