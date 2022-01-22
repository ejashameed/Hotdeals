using Hotdeals.Application.Gateway;
using Hotdeals.Application.ProductService.ProductDTOs;
using Hotdeals.Domain.ECommerceDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.GetProducts
{
    public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Products> products = await _productRepository.GetAllAsync();
            var productsDTOs = products.Select(x => new ProductDTO { ProductId = x.ProductId, ProductName = x.ProductName, });
            return productsDTOs;            
        }
    }
}
