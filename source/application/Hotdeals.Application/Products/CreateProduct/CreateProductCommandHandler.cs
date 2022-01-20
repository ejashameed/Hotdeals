using Hotdeals.Application.Gateway;
using Hotdeals.Application.Products.ProductDTOs;
using Hotdeals.Domain.ECommerceDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotdeals.Application.Products.CreateProduct
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
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
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
