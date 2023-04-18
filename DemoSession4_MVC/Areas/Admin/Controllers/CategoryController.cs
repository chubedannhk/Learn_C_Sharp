using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/category")]
public class CategoryController : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
