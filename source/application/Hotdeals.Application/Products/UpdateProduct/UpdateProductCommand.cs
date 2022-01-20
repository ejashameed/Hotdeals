using Hotdeals.Application.Products.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hotdeals.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
