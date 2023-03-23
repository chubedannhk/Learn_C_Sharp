using DemoSesion2_MVC.Models;
using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace DemoSesion2_MVC.Controllers;
[Route("account")]
public class AccountController : Controller
{
    private AccountService acccountService;
    public AccountController(AccountService _accountService)
    {
        acccountService = _accountService;
    }

    [Route("")]
   // [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        return View("index");
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        if(acccountService.login(username, password))
        {
            HttpContext.Session.SetString("username",username);
            return RedirectToAction("welcome");
        }
        else
        {
            // session flash 
            // ViewBag.msg = "Invalid fail";
            TempData["msg"] = "Invalid fail";
            return RedirectToAction("index");
        }
 
    }
    [Route("welcome")]
    public IActionResult Welcome()
    {
        ViewBag.username = HttpContext.Session.GetString("username");
        return View("welcome");
    }

    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index");
    }

    [Route("profile")]
    public IActionResult Profile()
    {
        var account = acccountService.find(HttpContext.Session.GetString("username"));

       return View("profile",account);
    
    }


}

