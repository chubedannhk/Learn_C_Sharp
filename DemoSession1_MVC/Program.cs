var builder = WebApplication.CreateBuilder(args);
// add để bk đang cần dùng controllers vs view
builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
// thế cấu hình đường dẫn lại vào đây

// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();
//================================
app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index3}");
app.Run();
