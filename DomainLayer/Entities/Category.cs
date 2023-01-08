using DomainLayer.Common;
using System.Collections.Generic;

namespace DomainLayer.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
