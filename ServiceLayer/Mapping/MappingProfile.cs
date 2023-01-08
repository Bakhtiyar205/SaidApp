using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTO.Category;
using ServiceLayer.DTO.Product;
using ServiceLayer.DTO.ProductImage;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductImage, ProductImageDTO>();
            CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
        }
    }
}
