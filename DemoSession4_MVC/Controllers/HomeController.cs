using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession4_MVC.Controllers;
[Route("home")]
public class HomeController : Controller
{
   
  //  [Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {

        return View();
    }

}
