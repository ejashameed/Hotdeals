using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.ProductDTOs
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            ProductTags = new HashSet<ProductTagDTO>();
            //Category = new CategoryDTO();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        public long? CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? IsActive { get; set; }

        public virtual CategoryDTO? Category { get; set; }
        public virtual ICollection<ProductTagDTO>? ProductTags { get; set; }

    }
}
