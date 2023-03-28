using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("contact")]
public class ContactController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}
