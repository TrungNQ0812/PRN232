using BusinessObject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
	public class eStoreDbContext : IdentityDbContext<ApplicationUser>
	{
		public eStoreDbContext(DbContextOptions<eStoreDbContext> options) : base(options) { }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderDetail>(entity =>
			{
				entity.HasKey(od => new { od.OrderId, od.ProductId });

				entity.Property(od => od.UnitPrice)
				.HasPrecision(18, 2);

				entity.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductId);

				entity.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(od => od.OrderId);
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.Property(o => o.Freight)
				.HasPrecision(18, 2);

				entity.HasOne(o => o.Member)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.MemberId);
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.Property(p => p.UnitPrice)
				.HasPrecision(18, 2);
			});
		}
	}
}
