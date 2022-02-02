using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.GetProductByCategory
{
    public class GetProductByCategoryQuery: IRequest<IEnumerable<ProductDTO>>
    {
        public  long Id { get; set; }
    }
}
