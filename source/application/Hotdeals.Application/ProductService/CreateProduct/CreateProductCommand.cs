using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.CreateProduct
{
    public class CreateProductCommand: IRequest<ProductDTO>
    {
        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? IsActive { get; set; }
        public long CategoryId { get; set; }
        public ICollection<ProductTagDTO>? ProductTags { get; set; }
    }
}
