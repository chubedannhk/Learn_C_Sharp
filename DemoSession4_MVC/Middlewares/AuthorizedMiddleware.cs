using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DemoSession4_MVC.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class AuthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext, AccountService accountService)
    {
        var username = httpContext.Session.GetString("username");
        var account = accountService.findByUsername(username);
        httpContext.Items["account"] = account;
        return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class AuthorizedMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthorizedMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthorizedMiddleware>();
    }
}
