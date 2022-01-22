using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {

    }
}
