using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("home")]
public class HomeController : Controller
{
    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
