using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Hotdeals.Application.Gateway;
using Hotdeals.Application.ProductService.ProductDTOs;
using AutoMapper;
using Hotdeals.Domain.ECommerceDomain.Entities;

namespace Hotdeals.Application.ProductService.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
         }

        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request),"Input Request is empty");

            //map dto product to domain entity
            var product = _mapper.Map<Product>(request);

            // update entity in database
            var updatedProduct = await _productRepository.UpdateAsync(product);

            // map result to DTO
            var response =  _mapper.Map<ProductDTO>(updatedProduct);

            return response;

        }
    }
}
