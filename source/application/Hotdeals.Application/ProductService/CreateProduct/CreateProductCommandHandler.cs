using AutoMapper;
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
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request),"Input is empty");

            //map from DTO to domain entity
            var product = _mapper.Map<Product>(request);

            //insert into database
            var newProduct = await _productRepository.AddAsync(product);

            // map result entity to ProductDTO
            var response = _mapper.Map<ProductDTO>(newProduct);
            return response;
        }
    }
}
