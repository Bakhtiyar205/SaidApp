using FluentValidation;
using Microsoft.AspNetCore.Http;
using ServiceLayer.DTO.Category;
using ServiceLayer.DTO.ProductImage;
using System;
using System.Collections.Generic;

namespace ServiceLayer.DTO.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public CategoryDTO Category { get; set; }
        public int CategoryId { get; set; }
        public List<ProductImageDTO> Images { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(m => m.FormFile).NotEmpty()
                                   .NotNull()
                                   .WithMessage("Please add Image");
        }
    }
}
