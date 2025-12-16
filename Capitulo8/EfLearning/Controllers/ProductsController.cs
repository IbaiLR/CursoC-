using EfLearning.Services;
using EfLearning.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EfLearning.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAll();
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProductCreateViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        try
        {
            _productService.Create(vm);
            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(vm);
        }
    }
}
