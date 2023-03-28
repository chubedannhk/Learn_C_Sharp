using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("account")]
public class AccountController : Controller
{
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [Route("register")]
    public IActionResult Register()
    {
        return View();
    }
}
