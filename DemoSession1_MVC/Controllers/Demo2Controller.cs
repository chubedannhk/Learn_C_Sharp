using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

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
    /*http://localhost:123/demo2/index5key=value&key=value */
    //cai nay dung de lam api

    [Route("index5")]
    public IActionResult Index5(int id, string username)
    {
        Debug.WriteLine("id: " + id);
        Debug.WriteLine("username: " + username);
        return View("Index5");
    }

    // redireacttoaction : dung de su ly chuc nag gi do xong , sau do tra ve mot cai gi do
    [Route("index6")]
    public IActionResult Index6()
    {
        //xxx
        return RedirectToAction("Index4","demo2");
    }
}
