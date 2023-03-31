using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("account")]
public class AccountController : Controller
{
    private AccountService accountService;
    public AccountController(AccountService _accountService)
    {
        accountService = _accountService;
    }
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.account = accountService.findAll();
        return View();
    }
    [Route("detail/{id}")]
    public IActionResult Detail(int id)
    {
        ViewBag.account = accountService.findById(id);
        return View();
    }
}
