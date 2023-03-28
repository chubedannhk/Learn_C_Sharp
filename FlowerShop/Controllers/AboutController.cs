using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("about")]
public class AboutController : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
