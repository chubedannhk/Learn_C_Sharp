﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoSession4_MVC.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class Log1Middleware
{
    private readonly RequestDelegate _next;

    public Log1Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        httpContext.Items.Add("id", 123);
        httpContext.Items.Add("username", "nguyenhoangkhai");
        // huy id
        httpContext.Items.Remove("id");
        Debug.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class Log1MiddlewareExtensions
{
    public static IApplicationBuilder UseLog1Middleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Log1Middleware>();
    }
}
