using DemoSesion2_MVC.Models;
using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoSesion2_MVC.Controllers;
[Route("cart")]
public class CartController : Controller
{
    private ProductService productService;
    public CartController(ProductService _productService)
    {
       productService = _productService;
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("cart") != null)
        {
            ViewBag.cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
        }
        return View("Index");
    }
    // ham xu ly mua san pham
    [Route("buy/{id}")]
    public IActionResult Buy(int id)
    {
        // lay san pham ra
        var product = productService.find(id);
        if(HttpContext.Session.GetString("cart") == null)
        {
            var cart = new List<Item>();
            cart.Add(new Item
            {
                Product = product,
                Quantity = 1,

            });
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        else{ 
            var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            cart.Add(new Item
            {
                Product = product,
                Quantity = 1,

            });
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        return RedirectToAction("index");
    }
}
