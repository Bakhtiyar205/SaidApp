using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.DTO.Product;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IValidator<ProductDTO>, ProductDTOValidator>();


            return services;
        }
    }
}
