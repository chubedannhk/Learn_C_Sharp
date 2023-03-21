using DemoSesion2_MVC.Services;

var builder = WebApplication.CreateBuilder(args);
// add để bk đang cần dùng controllers vs view
builder.Services.AddControllersWithViews();
// add session
builder.Services.AddSession();
// cai cau hinh moi
builder.Services.AddScoped<DemoService, DemoServiceImpl>();
builder.Services.AddScoped<CalculateService, CalculateServiceImpl>();
builder.Services.AddScoped<RectangleService, RectangleServiceImpl>();

builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
//=======
var app = builder.Build();
// khai bao de su dung session
app.UseSession();
//app.MapGet("/", () => "Hello World!");
// thế cấu hình đường dẫn lại vào đây

// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();
//================================
//app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index}");
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.Run();
