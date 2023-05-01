using AccountBank.Models;
using AccountBank.Service;
using Microsoft.AspNetCore.Mvc;

namespace AccountBank.Controllers;
[Route("register")]
public class RegisterController : Controller
{
    private AccountService accountService;
  
    public RegisterController(AccountService _accountService)
    {
        accountService = _accountService;
    }

    [Route("index")]
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        var account = new Account();
        return View("index", account);
      
    }

    [HttpPost]
    [Route("index")]
    public IActionResult Index(Account account)
    {
        if (account.Username != null && accountService.Exists(account.Username))
        {
            ModelState.AddModelError("Username", "Username da ton tai ");
        }
        //if (ModelState.ContainsKey("Username"))
        //{
        //    ViewBag.UsernameError = ModelState["Username"].Errors.FirstOrDefault().ErrorMessage;
        //}
        // kiem tra du lieu co hop le khong
        if (ModelState.IsValid)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            if (accountService.Create(account))
            {
                return RedirectToAction("index","login");
            }
            else
            {
                TempData["msg"] = "Register Failed";
                return RedirectToAction("index");
            }
        }
        else
        {
            return View("index");
        }

    }
}
