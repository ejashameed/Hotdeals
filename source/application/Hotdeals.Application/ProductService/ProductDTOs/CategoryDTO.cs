using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.ProductDTOs
{
    public class CategoryDTO
    {
        
        public long Id { get; set; }
        public string? CategoryName { get; set; }
        public int? IsActive { get; set; }
    }
}
