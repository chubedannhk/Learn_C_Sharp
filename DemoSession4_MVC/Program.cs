﻿
using DemoSession4_MVC.Middlewares;
using DemoSession4_MVC.Models;
using DemoSession4_MVC.Service;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();
//


// add để bk đang cần dùng controllers vs view

builder.Services.AddControllersWithViews();

//=======
var app = builder.Build();

// khai bao de su dung session
app.UseSession();
// goi ra middleware
app.UseMiddleware<AdminMiddleware>();
app.UseMiddleware<Log1Middleware>();
app.UseMiddleware<SecurityMiddleware>();
app.UseMiddleware<Log2Middleware>();
app.UseMiddleware<Log3Middleware>();
app.UseMiddleware<AuthorizedMiddleware>();
// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();

//================================
//app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index}");
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.Run();