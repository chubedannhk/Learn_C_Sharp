using FlowerShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("home")]
public class HomeController : Controller
{
    private ProductService productService;
    public HomeController(ProductService _productService) { 
        productService = _productService;
    }
    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.productsLastest = productService.sortPro(3);
        ViewBag.FeaturedProducts = productService.Featured(2);
        return View();
    }
}
