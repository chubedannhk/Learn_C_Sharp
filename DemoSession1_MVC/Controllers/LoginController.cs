using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession1_MVC.Controllers;
[Route("login")]
public class LoginController : Controller
{
    [Route("")]
    [Route("index")]
   // [Route("~/")]
    public IActionResult Index()
    {
        var login = new Login()
        {

        };
        var countryModel = new CountryModel();
        ViewBag.country = countryModel.findAll();

        var statusModel = new StatusModel();
        ViewBag.status = statusModel.findAll();
        return View("Index");
    }

    [HttpPost]
    [Route("save")]
    public IActionResult Save(Login login)
    {
        // name
        Debug.WriteLine($"Your Name is: {login.firstName} {login.lastName}");
        // special needs 
        Debug.WriteLine($"Special needs is: {login.speciallNeeds} ");
        // email
        Debug.WriteLine($"Email is: {login.email} ");

        // address
        Debug.WriteLine($"Address is-> Street:{login.infoAddress.Street}, Street 2:{login.infoAddress.Street2}, " +
            $"City:{login.infoAddress.City},State:{login.infoAddress.State}, Postal:{login.infoAddress.Postal}, Country: {login.infoAddress.Country}");

        // phone number
        Debug.WriteLine($"Phone Number is: {login.Phone.num1} "+$"{login.Phone.num2} "+$"{login.Phone.num3}");
        // date 
        Debug.WriteLine($"StartDate : {login.startDate.ToString("yyyy-MM-dd")}");
        Debug.WriteLine($"EndDate : {login.endDate.ToString("yyyy-MM-dd")}");
        // status
        Debug.WriteLine($"Status: {login.Status}");
        return RedirectToAction("index", "login");
    }
}
