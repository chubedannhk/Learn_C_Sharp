using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DemoSession1_MVC.Controllers;
[Route("demo2")]
//[Route("abc")]
public class Demo2Controller : Controller
{
    [Route("index")]
    [Route("def")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
    [Route("index2/{id}")]
    [Route("{id}")]
    public IActionResult Index2(int id)
    {
        Debug.WriteLine("id: " + id);
        return View("Index2");
    }

    [Route("index3/{id}/{username}")]
    //[Route("{id}/{username}")]
    public IActionResult Index3(int id, string username)
    {
        Debug.WriteLine("id: " + id);
        Debug.WriteLine("username: " + username);
        return View("Index3");
    }
    [Route("index4")]
    public IActionResult Index4()
    {
      
        return View("Index4");
    }
}
