using Hotdeals.Application.Products.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ProductDTO>
    {
        public Guid ProductId { get; set; }

    }
}
