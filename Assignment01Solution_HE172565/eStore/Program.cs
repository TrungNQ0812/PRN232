using DataAccess;
using DataAccess.DAOs;
using DataAccess.Repositories;
using eStoreAPI.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register HttpClient in DI container
//builder.Services.AddHttpClient();
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});

// Register the required repositories for dependency injection
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

// Register other services like DbContext and HttpClient
builder.Services.AddScoped<MemberDAO>();
builder.Services.AddScoped<OrderDAO>();
builder.Services.AddScoped<ProductDAO>();
builder.Services.AddScoped<OrderDetailDAO>();
builder.Services.AddScoped<MemberAPI>();
builder.Services.AddScoped<OrderAPI>();
builder.Services.AddScoped<ProductAPI>();
builder.Services.AddScoped<OrderDetailAPI>();

builder.Services.AddDbContext<eStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eStoreDb")));

// No need to manually register controllers like this. ASP.NET Core automatically discovers and injects controllers.
builder.Services.AddControllers();

//register for session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Index");
}

app.MapControllers();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
