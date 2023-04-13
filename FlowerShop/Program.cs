using FlowerShop.Models;
using FlowerShop.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// add để bk đang cần dùng controllers vs view
builder.Services.AddControllersWithViews();
// doc chuoi ket noi ra va ket noi db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
//=======

builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();
var app = builder.Build();
// khai bao de su dung session



// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();
//================================
//app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index}");
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.Run();
