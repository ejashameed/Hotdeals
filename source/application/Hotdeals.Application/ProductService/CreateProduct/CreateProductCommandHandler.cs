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

namespace Hotdeals.Application.ProductService.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Products
            {
                ProductId = Guid.NewGuid().ToString(),
                ProductName = request.ProductName,
            };

            var newProduct = await _productRepository.AddAsync(product);

            var productDTO = new ProductDTO
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
            };

            return productDTO;
        }
    }
}
