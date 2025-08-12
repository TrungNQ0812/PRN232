using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
	public interface IUnitOfWork
	{
		public ProductRepository Products { get; }
		public ICategoryRepository Categories { get; }
		public IOrderRepository Orders { get; }
		public IOrderDetailRepository OrderDetails { get; }
		public IApplicationUserRepository ApplicationUsers { get; }
		public Task SaveAsync();
	}

	public class UnitOfWork : IUnitOfWork
	{
		private readonly eStoreDbContext _context;

		public ProductRepository Products { get; }

		public ICategoryRepository Categories { get; }

		public IOrderRepository Orders { get; }

		public IOrderDetailRepository OrderDetails { get; }

		public IApplicationUserRepository ApplicationUsers { get; }

		public UnitOfWork(
			eStoreDbContext context,
			ProductRepository productRepository,
			ICategoryRepository categoryRepository,
			IOrderRepository orderRepository,
			IOrderDetailRepository orderDetailRepository,
			IApplicationUserRepository applicationUserRepository)
		{
			_context = context;
			Products = productRepository;
			Categories = categoryRepository;
			Orders = orderRepository;
			OrderDetails = orderDetailRepository;
			ApplicationUsers = applicationUserRepository;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
