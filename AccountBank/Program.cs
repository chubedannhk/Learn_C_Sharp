
using AccountBank.Models;
using AccountBank.Service;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();



// doc chuoi ket noi ra va ket noi db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

//
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<TransactionDetailService, TransactionDetailServiceImpl>();
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
