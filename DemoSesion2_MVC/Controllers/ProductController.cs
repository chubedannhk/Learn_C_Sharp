using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSesion2_MVC.Controllers;
[Route("product")]
public class ProductController : Controller
{
    private ProductService productService;

    // injection
    public ProductController(ProductService _productService)
    {
        productService = _productService;
    }  
    [Route("")]
    [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.product = productService.findAll();
        return View();
    }
}
