using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers;
[Route("product")]
public class ProductController : Controller
{
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
}
