using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.GetProductsById
{
    public class GetProductsByIdQuery: IRequest<ProductDTO>
    {
        public string ProductId { get; set; }
    }
}
    