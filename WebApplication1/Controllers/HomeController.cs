using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService,
                              IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Categories = await _categoryService.GetAllAsync(),
                ElectricProducts = await _productService.GetElectricAsync(),
                Products = await _productService.GetSpecificAsync()
            };
            return View(homeVM);
        }
    }
}
