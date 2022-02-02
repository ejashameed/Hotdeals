using System;
using System.Collections.Generic;

#nullable disable

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductTags = new HashSet<ProductTag>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string IsActive { get; set; }
        public long? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductTag>? ProductTags { get; set; }
    }
}
