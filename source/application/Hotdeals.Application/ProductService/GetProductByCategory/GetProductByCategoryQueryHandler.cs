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

namespace Hotdeals.Application.ProductService.GetProductByCategory
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await _productRepository.GetByCategory(request.Id);
            var productList = _mapper.Map<IEnumerable<ProductDTO>>(products);            
            return productList;
        }
               
    }
}
