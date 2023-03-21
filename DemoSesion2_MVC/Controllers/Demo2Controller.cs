using DemoSesion2_MVC.Models;
using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DemoSesion2_MVC.Controllers;
[Route("demo2")]
public class Demo2Controller : Controller
{
    private ProductService productService;
    public Demo2Controller(ProductService _productService)
    {
        productService = _productService;
    }
    [Route("")]
   // [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        Debug.WriteLine(BCrypt.Net.BCrypt.HashPassword("123"));
        Debug.WriteLine(BCrypt.Net.BCrypt.HashPassword("123"));
        Debug.WriteLine(BCrypt.Net.BCrypt.HashPassword("123"));
        HttpContext.Session.SetInt32("id", 123);
        HttpContext.Session.SetString("userName", "nguyenhoangkhai");

        var product = productService.find(1);
        string s = JsonConvert.SerializeObject(product);
        Debug.WriteLine(s);
        // giu lai gia tri json cua thong tin san pham
        HttpContext.Session.SetString("Product", s);

        // lay ra nguyen danh sach san pham
        var products = productService.findAll();
        string s2 = JsonConvert.SerializeObject(products);
        Debug.WriteLine(s2);
        HttpContext.Session.SetString("products", s2);
        // huy session
        //HttpContext.Session.Remove("userName");
        return RedirectToAction("index2");
    }
    [Route("index2")]
    public IActionResult Index2()
    {
        if (HttpContext.Session.GetString("id") != null || HttpContext.Session.GetString("userName") != null)
        {
            var id = HttpContext.Session.GetInt32("id");
            var userName = HttpContext.Session.GetString("userName");
            Debug.WriteLine($"Session Id: {id}");
            Debug.WriteLine($"Session UserName: {userName}");
        }

        // doc session da lay phia tren
        if (HttpContext.Session.GetString("Product") != null)
        {
            Product product = JsonConvert.DeserializeObject<Product>(HttpContext.Session.GetString("Product"));
            Debug.WriteLine("Product Info");
            Debug.WriteLine($"id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        // doc product list 
        if (HttpContext.Session.GetString("products") != null)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(HttpContext.Session.GetString("products"));
            Debug.WriteLine("List Product");
            products.ForEach(p =>
            {
                 Debug.WriteLine($"id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
            });
        }
        return View("index");
    }
}

