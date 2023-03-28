using Microsoft.AspNetCore.Mvc;

namespace DemoSession3_MVC.Areas.Admin.Controllers;
//area/controller/action/params
[Area("admin")]
[Route("admin/invoice")]
public class InvoiceController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("add")]
    public IActionResult Add()
    {
        return View();
    }
}
