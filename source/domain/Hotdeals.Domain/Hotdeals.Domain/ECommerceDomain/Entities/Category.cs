using System;
using System.Collections.Generic;

#nullable disable

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string CategoryName { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
