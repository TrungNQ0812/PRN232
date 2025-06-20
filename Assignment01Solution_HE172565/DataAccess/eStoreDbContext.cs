﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DataAccess
{
    public class eStoreDbContext : DbContext
    {
        public eStoreDbContext(DbContextOptions<eStoreDbContext> options) 
            : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=eStoreDb;Trusted_Connection=True;TrustServerCertificate=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OrderDetail: Composite Primary Key
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            // Product → Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Order → Member 
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Member)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.MemberId)
                .OnDelete(DeleteBehavior.Cascade); 

            // OrderDetail → Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderDetail → Product
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);
            /*
            // ✅ Optional navigation: avoid validation error when not included
            modelBuilder.Entity<Member>()
                .Navigation(m => m.Orders);

            modelBuilder.Entity<Product>()
                .Navigation(p => p.OrderDetails)
                .IsRequired(false);

            modelBuilder.Entity<Category>()
                .Navigation(c => c.Products)
                .IsRequired(false);

            modelBuilder.Entity<Order>()
                .Navigation(o => o.OrderDetails)
                .IsRequired(false);
            */
        }
    }
}
