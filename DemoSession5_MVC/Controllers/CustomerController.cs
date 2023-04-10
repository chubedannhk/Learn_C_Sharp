using Microsoft.AspNetCore.Mvc;
using QuanLyHoaDon.Models;
using QuanLyHoaDon.Service;

namespace QuanLyHoaDon.Controllers;
[Route("customer")]
public class CustomerController : Controller
{
    private CustomerService customerService;
    public CustomerController(CustomerService _customerService) {
       customerService = _customerService;
    }
    [Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.customer = customerService.findAll();
        return View();
    }

    // change profile
    [Route("update/{id}")]
    public IActionResult Update(int id)
    {
        var customer = customerService.findById(id);
        return View("update", customer);
    }

    [HttpPost]
    [Route("update/{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        customer.Id = id;
        if (customerService.Update(customer))
        {
            TempData["msg"] = "Change Profile Success";
        }
        else
        {
            TempData["msg"] = "Change Profile Failed";
        }

        return RedirectToAction("Index");
    }

    
}
