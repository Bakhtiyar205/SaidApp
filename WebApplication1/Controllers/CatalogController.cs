using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CatalogController(ICategoryService categoryService,
                              IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                CatalogVM catalogVM = new CatalogVM()
                {
                    Categories = await _categoryService.GetAllAsync(),
                    Products = await _productService.GetAllAsync()
                };
                return View(catalogVM);
            }
            else
            {
                int newId = (int)id;
                CatalogVM catalogVM = new CatalogVM()
                {
                    Categories = await _categoryService.GetAllAsync(),
                    Products = await _productService.GetCategoryIdAsync(newId)
                };
                return View(catalogVM);
            }
            
        }
    }
}
