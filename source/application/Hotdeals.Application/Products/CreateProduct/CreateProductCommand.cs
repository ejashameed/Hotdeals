using Hotdeals.Application.Products.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.Products.CreateProduct
{
    public class CreateProductCommand: IRequest<ProductDTO>
    {        
        public string ProductName { get; set; }
    }
}
