using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PRN232_PT1_TrungNQHE172565.Models;

namespace PRN232_PT1_TrungNQHE172565;

public partial class Prn232dbContext : DbContext
{

    private readonly IConfiguration configuration;
    public Prn232dbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public Prn232dbContext(DbContextOptions<Prn232dbContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = configuration.GetConnectionString("PRN232PT1DB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA7945A968C1");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmpID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.EmpName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Idcard)
                .HasMaxLength(20)
                .HasColumnName("IDCard");
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFACD1A6FB");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("OrderID");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Emp).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Order__EmpID__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
