using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public HeaderViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeaderVM  headerVM = new HeaderVM()
            {
                Categories = await _categoryService.GetAllAsync()
            };
            return await Task.FromResult(View(headerVM));
        }
    }
}
