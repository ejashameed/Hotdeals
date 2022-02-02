using System;
using System.Collections.Generic;

#nullable disable

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class ProductTag
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string TagName { get; set; }
        public int IsActive { get; set; }

        public virtual Product Product { get; set; }
    }
}
