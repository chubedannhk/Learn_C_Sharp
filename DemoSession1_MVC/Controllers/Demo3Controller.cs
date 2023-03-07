using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession1_MVC.Controllers;
[Route("demo3")]
public class Demo3Controller : Controller
{
    [Route("index")]
    [Route("")]
    //[Route("~/")]
    public IActionResult Index()
    {
      
        return View();
    }
    //
    [Route("searchByKeyword")]
    public IActionResult SearchByKeyword(string keyword)
    {
        Debug.WriteLine("keyword: "+keyword);
        return View("index");
    }
    //
    [Route("searchByPrices")]
    public IActionResult SearchByPrices(double min, double max)
    {
        Debug.WriteLine("MIN: " + min);
        Debug.WriteLine("MAX: " + max);
        return View("index");
    }
}
