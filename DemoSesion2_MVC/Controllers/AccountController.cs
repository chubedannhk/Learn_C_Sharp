using DemoSesion2_MVC.Models;
using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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
    [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        return View("index");
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Welcome()
    {
        return View("welcome");
    }
}

