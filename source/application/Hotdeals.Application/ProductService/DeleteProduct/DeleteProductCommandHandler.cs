using Hotdeals.Application.Gateway;
using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotdeals.Application.ProductService.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _productRepository.RemoveAsync(request.ProductId);
            var productDTO = new ProductDTO { ProductId = deletedProduct.ProductId, ProductName = deletedProduct.ProductName };

            return productDTO;
        }
    }
}
