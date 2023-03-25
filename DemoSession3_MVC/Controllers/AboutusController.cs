using Microsoft.AspNetCore.Mvc;

namespace DemoSession3_MVC.Controllers;
[Route("aboutus")]
public class AboutusController : Controller
{
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}
