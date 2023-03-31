using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("product")]
public class ProductController : Controller
{
    private ProductService productService;
    public ProductController(ProductService _productService)
    {
        productService = _productService;
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.product = productService.findAll();
        return View();
    }

    [Route("detail/{id}")]
    public IActionResult Detail(int id)
    {
        ViewBag.detail = productService.findById(id);
        return View();
    }
}
