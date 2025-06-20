using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repositories;
using DataAccess.DAOs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<MemberDAO>();
builder.Services.AddScoped<OrderDAO>();
builder.Services.AddScoped<ProductDAO>();
builder.Services.AddScoped<OrderDetailDAO>();


//Register DbContext
builder.Services.AddDbContext<eStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eStoreDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
