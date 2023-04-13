using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("demo2")]
public class Demo2Controller : Controller
{
  //  [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
