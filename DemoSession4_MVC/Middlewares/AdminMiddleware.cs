using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoSession4_MVC.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class AdminMiddleware
{
    private readonly RequestDelegate _next;

    public AdminMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        // kiem tra ai do muon vao admin.
        var url = httpContext.Request.Path.ToString();
        //Debug.WriteLine("url: " + url);
        if (url.StartsWith("/admin"))
        {
            if(httpContext.Session.GetString("username") == null)
            {
                httpContext.Response.Redirect("/account/login");
            }
        }
        return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class AdminMiddlewareExtensions
{
    public static IApplicationBuilder UseAdminMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AdminMiddleware>();
    }
}
