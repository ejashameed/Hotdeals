using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hotdeals.Application.ProductService.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
