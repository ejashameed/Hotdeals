using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.ProductDTOs
{
    public class ProductTagDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string? TagName { get; set; }
        public int IsActive { get; set; }
    }
}
