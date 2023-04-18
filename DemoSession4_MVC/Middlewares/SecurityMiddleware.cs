using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DemoSession4_MVC.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class SecurityMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, AccountService accountService)
    {
        // co che bao mat
        // var status = true;
        var status = accountService.Login("nguyenhoangkhai", "123");
        if (!status)
        {
            return;
        }
        await _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class SecurityMiddlewareExtensions
{
    public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SecurityMiddleware>();
    }
}
