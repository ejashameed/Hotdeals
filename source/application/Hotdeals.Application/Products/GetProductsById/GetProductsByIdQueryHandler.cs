using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hotdeals.Application.Gateway;
using Hotdeals.Application.Products.ProductDTOs;
using MediatR;

namespace Hotdeals.Application.Products.GetProductsById
{
    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            var productDTO = new ProductDTO { ProductId = product.ProductId, ProductName = product.ProductName };
            return productDTO;
        }
    }
}
