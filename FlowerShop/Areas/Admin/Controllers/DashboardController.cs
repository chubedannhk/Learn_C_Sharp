using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/dashboard")]
public class DashboardController : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
