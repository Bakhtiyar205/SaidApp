using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.DTO.Category;
using ServiceLayer.DTO.Product;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Areas.AdminArea.ViewModel;
using WebApplication1.Utilities.Helpers;

namespace WebApplication1.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IValidator<ProductDTO> _validator;

        public ProductController(ICategoryService categoryService,
                              IProductService productService,
                              IValidator<ProductDTO> validator)
        {
            _categoryService = categoryService;
            _productService = productService;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            ProductsVM products = new()
            {
                Products = await _productService.GetAllAsync()
            };
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            await _productService.SoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SelectList = await GetSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            ViewBag.SelectList = await GetSelectList();
            if (productDTO is null) BadRequest();

            ValidationResult results = await _validator.ValidateAsync(productDTO);

            if (!results.IsValid)
            {
                results.AddToModelState(this.ModelState);
            }
            if (!ModelState.IsValid) return View(productDTO);
            await _productService.CreateAsync(productDTO);
            return RedirectToAction(nameof(Index));

        }

        private async Task<SelectList> GetSelectList()
        {
            List<CategoryDTO> categories = await _categoryService.GetAllAsync();
            return new SelectList(categories, "Id", "Name");
        }
    }
}
