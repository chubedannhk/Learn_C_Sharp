using Microsoft.AspNetCore.Mvc;

namespace DemoSession3_MVC.Controllers;
[Route("news")]
public class NewsController : Controller
{
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}
