using Microsoft.AspNetCore.Mvc;
using QuanLyHoaDon.Models;
using QuanLyHoaDon.Service;

namespace QuanLyHoaDon.Controllers;
[Route("orders")]
public class OrdersController : Controller
{
    
    private OrdersService ordersService;
    public OrdersController( OrdersService _ordersService)
    {
       
        ordersService = _ordersService;
    }

    [Route("index/{id}")]
    public IActionResult Index(int id)
    {
        ViewBag.viewOrder = ordersService.findCustomerId(id);
        return View();
    }

    [Route("add/{id}")]
    public IActionResult Add(int id)
    {
        
       // var customer = customerService.findById(id);
        var order = new Order()
        {
            Datecreation = DateTime.Now,
            Customerid = id,
        };
        return View("add",order);
    }
    [HttpPost]
    [Route("addOrder")]
    public IActionResult AddOrder(Order order)
    {
        
        if (ordersService.Create(order))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }
        return RedirectToAction("index","customer");
        
    }

    // xoa hoa don 
    [Route("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var customer = ordersService.findCustomerId(id);
        if (ordersService.Delete(id))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }
        return RedirectToAction("index", "orders", new
        {
            id = customer
        });
    }
}
