using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public FooterViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footerVM = new FooterVM()
            {
                Categories = await _categoryService.GetAllAsync()
            };
            return await Task.FromResult(View(footerVM));
        }
    }
}
