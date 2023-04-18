using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/invoice")]
public class InvoiceController : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
