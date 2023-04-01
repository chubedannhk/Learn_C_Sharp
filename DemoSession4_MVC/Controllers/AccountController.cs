using DemoSession1_MVC.Helpers;
using DemoSession4_MVC.Models;
using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Hosting;
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
    [Route("~/")]
    [Route("")]
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
    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        var account = new Account();
      
        return View("add", account);
    }


    [HttpPost]
    [Route("add")]
    public IActionResult Add(Account account)
    {
        // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(account.Password);

        // Gán mật khẩu đã mã hóa vào account
        account.Password = hashedPassword;

        // Thực hiện lưu account vào cơ sở dữ liệu
        if (accountService.Create(account))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }

        return RedirectToAction("Index");
    }

}
