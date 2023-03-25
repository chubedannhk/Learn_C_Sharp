using Microsoft.AspNetCore.Mvc;

namespace DemoSession3_MVC.HomeController;
[Route("home")]
public class HomeController : Controller
{
    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View("index");
    }
}
