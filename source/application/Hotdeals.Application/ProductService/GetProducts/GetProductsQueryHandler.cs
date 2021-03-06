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

namespace Hotdeals.Application.ProductService.GetProducts
{
    public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            var productList = _mapper.Map<List<ProductDTO>>(products);            
            return productList;            
        }        
    }
}
