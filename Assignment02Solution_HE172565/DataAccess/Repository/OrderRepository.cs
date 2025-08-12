using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
	}

	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(eStoreDbContext context) : base(context)
		{
		}
	}
}
