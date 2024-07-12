using App.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Net.Controllers;
[Area("ProductManage")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
   
    private readonly ProductService _productService;

    public ProductController(ILogger<ProductController> logger,ProductService productService)
    {
        _logger = logger;
       
        _productService = productService;
    }
    public IActionResult Index()
    {
        var products = _productService.OrderBy(p => p.Name).ToList();
        return View(products);
    }

}