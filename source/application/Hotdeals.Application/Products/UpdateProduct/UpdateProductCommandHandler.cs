using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotdeals.Application.Products.ProductDTOs;
using System.Threading;
using Hotdeals.Application.Gateway;

namespace Hotdeals.Application.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            product.ProductName = request.ProductName;

            var updatedProduct = await _productRepository.UpdateAsync(product);

            return new ProductDTO { ProductId = updatedProduct.ProductId, ProductName = updatedProduct.ProductName };

        }
    }
}
