using DemoSession4_MVC.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession4_MVC.Controllers;
[Route("demo3")]
public class Demo3Controller : Controller
{
  //  [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        if (HttpContext.Items["id"] != null)
        {
            var id = int.Parse(HttpContext.Items["id"].ToString());
            Debug.WriteLine("id - log3: " + id);
        }
        if (HttpContext.Items["username"] != null)
        {
            var username = HttpContext.Items["username"].ToString();
            Debug.WriteLine("username - log3: " + username);
        }
        return View();
    }

    [MyAuthorized(Roles = "SuperAdmin")]
    [Route("index2")]
    public IActionResult Index2()
    {
        return View();
    }

    [MyAuthorized(Roles = "SuperAdmin,Admin")]
    [Route("index3")]
    public IActionResult Index3()
    {
        return View();
    }

    [MyAuthorized(Roles = "SuperAdmin,Admin,Employee")]
    [Route("index4")]
    public IActionResult Index4()
    {
        return View();
    }
}
