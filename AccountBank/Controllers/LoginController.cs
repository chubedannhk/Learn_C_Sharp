using AccountBank.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountBank.Controllers;
[Route("login")]
public class LoginController : Controller
{
    private AccountService accountService;

    public LoginController(AccountService _accountService)
    {
        accountService = _accountService;
    }
    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("index")]
    public IActionResult Index(string username, string password)
    {
        var user = accountService.findByUsername(username);
        if (accountService.Login(username, password))
        {
            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("phone", user.Phone);
            HttpContext.Session.SetString("fullname", user.Fullname);
            HttpContext.Session.SetString("balance", user.Balance.ToString());
            HttpContext.Session.SetString("accid", user.AccId.ToString());
            return RedirectToAction("index", "home");
        }
        else
        {
            TempData["msg"] = "Login Failed";
            return RedirectToAction("index","login");
        }
    }
}
