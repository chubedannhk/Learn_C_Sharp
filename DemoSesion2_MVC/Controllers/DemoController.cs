using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSesion2_MVC.Controllers;
[Route("demo")]
public class DemoController : Controller
{
    // tu nay viet thoe cach nay, chu khong co new ra nua
    private DemoService demoService;
    private CalculateService calculateService;
    private RectangleService rectangleService;
    // injection
    public DemoController(DemoService _demoService, CalculateService _calculateService, RectangleService _rectangleService) { 
        demoService = _demoService;
        calculateService = _calculateService;
        rectangleService = _rectangleService;
    }

  
   
    [Route("")]
    //[Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.msg1 = demoService.Hello();
        ViewBag.msg2 = demoService.Hi("nguyen hoang khai");

        ViewBag.msg3 = calculateService.Add(2, 3);
        ViewBag.msg4 = calculateService.Mul(3, 4);

        ViewBag.msg5 = rectangleService.Area(3,3);
        ViewBag.msg6 = rectangleService.Perimeter(3, 3);
        return View();
    }
}

