using Microsoft.AspNetCore.Mvc;

namespace DemoSession1_MVC.Controllers;
public class DemoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2()
    {
        return View("nguyenhoangkhai");
    }
}
