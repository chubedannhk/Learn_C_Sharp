
var builder = WebApplication.CreateBuilder(args);
// add để bk đang cần dùng controllers vs view
builder.Services.AddControllersWithViews();

//=======
var app = builder.Build();
// khai bao de su dung session


// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();
//================================
//app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index}");
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.Run();
