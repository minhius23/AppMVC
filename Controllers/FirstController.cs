using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppMVC.Net.Models;
using App.Service;

namespace AppMVC.Net.Controllers;

public class FirstController : Controller
{
    private readonly ILogger<FirstController> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly ProductService _productService;

    public FirstController(ILogger<FirstController> logger,IWebHostEnvironment env,ProductService productService)
    {
        _logger = logger;
        _env = env;
        _productService = productService;
    }

    public IActionResult Bird()
    {
        string filePath = Path.Combine(_env.ContentRootPath,"Files","a6.jpg");
        var bytes =  System.IO.File.ReadAllBytes(filePath);
        
        return  File(bytes, "image/jpg"); 
    }
    public IActionResult HelloView()
    {
        return View("/MyView/hello1.cshtml");
    }
    public IActionResult ViewProduct(int? id)
    {
        var product = _productService.Where( p => p.ID == id).FirstOrDefault();
        if(product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}
