using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hotdeals.Application.Gateway;
using Hotdeals.Application.ProductService.ProductDTOs;
using MediatR;

namespace Hotdeals.Application.ProductService.GetProductsById
{
    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var productItem = await _productRepository.GetByIdAsync(request.Id);
            var product = _mapper.Map<ProductDTO>(productItem);
            return product;

            //var productDTO = new ProductDTO 
            //{ 
            //    Id = product.Id, Name = product.Name, Description=product.Description,Price=product.Price,IsActive=product.IsActive,
            //    Category = new CategoryDTO
            //    {
            //        CategoryName=product.Category.CategoryName,
            //        IsActive=product.Category.IsActive,
            //        Id=product.Category.Id                                        
            //    },
            //    ProductTags = product.ProductTags.Select(x=> new ProductTagDTO { Id = x.Id, IsActive = x.IsActive, ProductId=x.ProductId, TagName=x.TagName}).ToList(),
            //};            
        }
    }
}
