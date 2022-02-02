using AutoMapper;
using Hotdeals.Application.ProductService.CreateProduct;
using Hotdeals.Application.ProductService.ProductDTOs;
using Hotdeals.Application.ProductService.UpdateProduct;
using Hotdeals.Domain.ECommerceDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.AutoMapping
{
    public class DTOtoDomainProfile: Profile
    {
        
        public DTOtoDomainProfile()
        {
            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.ProductTags, opt => opt.MapFrom(src=> src.ProductTags
                    .Select(x=> new ProductTag 
                        { Id=x.Id, IsActive=x.IsActive, ProductId=x.ProductId,TagName=x.TagName })));

            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.ProductTags, opt => opt.MapFrom(src => src.ProductTags
                    .Select(x => new ProductTag
                    { Id = x.Id, IsActive = x.IsActive, ProductId = x.ProductId, TagName = x.TagName })));

            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
