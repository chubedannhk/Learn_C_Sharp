using Azure;
using DemoSession4_MVC.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace DemoSession4_MVC.Attributes;

public class MyAuthorized : Attribute, IAuthorizationFilter
{
    public string Roles { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //Debug.WriteLine("Roles: " + Roles);
        if (context.HttpContext.Items["account"] == null)
        {
            context.HttpContext.Response.Redirect("/account/login");
        }
        else
        {
            var account = context.HttpContext.Items["account"] as Account;
            var roles = Roles.Split(new char[] { ',' });
            // neu tai khoan khong cho chua role nao het thi da no ve
            if (!account.Roles.Any(role => roles.Contains(role.Name)))
            {
                context.HttpContext.Response.Redirect("/account/accessDenied");
            }
        }
        
    }
}
