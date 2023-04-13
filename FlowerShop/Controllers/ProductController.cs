using FlowerShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("product")]
public class ProductController : Controller
{
	private ProductService productService;
	public ProductController(ProductService _productService)
	{
		productService = _productService;
	}
	[Route("flower")]
	public IActionResult Flower()
	{
		return View();
	}
	[Route("gift")]
	public IActionResult Gift()
	{
		return View();
	}
	[Route("price")]
	public IActionResult Price()
	{
		return View();
	}

	// details
	[Route("detail/{id}")]
    public IActionResult Detail(int id)
    {
		ViewBag.detailProduct = productService.findById(id);
        return View();
    }
}
