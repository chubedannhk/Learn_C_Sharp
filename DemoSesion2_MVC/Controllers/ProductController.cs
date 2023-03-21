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
   // [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.product = productService.findAll();
        return View();
    }

    // search keyword
    [Route("searchByKeyword")]
    public IActionResult SearchByKeyword(string keyword)
    { 
        ViewBag.product = productService.searchByKeyword(keyword);
        ViewBag.keyword = keyword;
        return View("index");
    }

    // search prices

    [Route("searchByPrices")]
    public IActionResult SearchByPrices(double min, double max)
    {
    
        ViewBag.product = productService.searchByPrices(min, max);
        // dong nay de luu lai ket qua vua tim kiem
        ViewBag.min = min;
        ViewBag.max = max;
        return View("Index");
    }

    [Route("searchByDateRange")]
    public IActionResult searchByDateRange(string from, string to)
    {

        ViewBag.product = productService.searchByDateRange(from, to);
        // dong nay de luu lai ket qua vua tim kiem
        ViewBag.from = from;
        ViewBag.to = to;
        return View("Index");
    }
}
