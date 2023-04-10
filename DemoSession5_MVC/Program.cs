
using Microsoft.EntityFrameworkCore;
using QuanLyHoaDon.Models;
using QuanLyHoaDon.Service;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();

//var key1 = builder.Configuration["Key1"];
//Debug.WriteLine("Key1 - program: "+key1);
//var key2 = builder.Configuration["Key2:Key22"];
//Debug.WriteLine("Key22 - program: " + key2);


// doc chuoi ket noi ra va ket noi db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

//
builder.Services.AddScoped<CustomerService,CustomerServiceImpl >();
builder.Services.AddScoped<OrdersService, OrdersServiceImpl>();
//


// add để bk đang cần dùng controllers vs view

builder.Services.AddControllersWithViews();

//=======
var app = builder.Build();
// khai bao de su dung session


// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();
app.UseSession();
//================================
//app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index}");
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.Run();
