using DomainLayer.Common;
using System;
using System.Collections.Generic;

namespace DomainLayer.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
