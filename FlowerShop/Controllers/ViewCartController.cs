using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("viewcart")]
public class ViewCartController : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
