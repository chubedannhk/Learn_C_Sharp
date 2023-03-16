using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession1_MVC.Controllers;
[Route("employee")]
public class EmployeeController : Controller
{

    [Route("")]
    [Route("index")]
  //  [Route("~/")]
    public IActionResult Index()
    {
        return View("Index", new Employee());
    }
    [Route("save")]
    public IActionResult Save(Employee employee)
    {
        // su ly du lieu ( Custom Validation)
        if(employee.Username != null && employee.Username == "hoangkhai")
        {
            ModelState.AddModelError("Username", "Username is existed");
        }
        // kiem tra dieu kien nhap vao
        if(ModelState.IsValid)
        {
            return View("Success");
        }
        else
        {
            return View("Index");
        }
        
    }
}
