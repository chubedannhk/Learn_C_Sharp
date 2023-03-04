using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DemoSession1_MVC.Controllers;
public class DemoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index2()
    {
        return View("nguyenhoangkhai");
    }

    public IActionResult Index3()
    {
        ViewBag.id = 123;
        ViewBag.username = "admin";
        ViewBag.price = 4;
        ViewBag.quantity = 3;
        ViewBag.photo = "angel.png";
        ViewBag.product = new Product
        {

            Id = 1,
            Name = "Nguyen HOang",
            Photo = "angel.png",
            Price = 5000,
            Quantity = 3,
            Created = DateTime.Now

        };
        ViewBag.names = new List<string>
        {
             "Name 1","Name 2","Name 3","Name 4","Name 5"
        };
        ViewBag.products = new List<Product>
        {
            
        new Product
        {
              Id = 1,
              Name = "Nguyen HOang",
              Photo = "angel.png",
              Price = 6000,
              Quantity = 3,
              Created = DateTime.Now
        },
        new Product
        {
              Id = 2,
              Name = "Nguyen Khair",
              Photo = "angel.png",
              Price = 5000,
              Quantity = 3,
              Created = DateTime.Now
        },
        new Product
        {
              Id = 3,
              Name = "Nguyen HOang Khai",
              Photo = "angel.png",
              Price = 4000,
              Quantity = 3,
              Created = DateTime.Now
        }
    
    };
        return View("index3");
    }
}
