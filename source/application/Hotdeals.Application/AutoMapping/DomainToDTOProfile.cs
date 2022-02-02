using AutoMapper;
using Hotdeals.Application.ProductService.ProductDTOs;
using Hotdeals.Domain.ECommerceDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.AutoMapping
{
    public class DomainToDTOProfile: Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductTags,
                    opt => opt.MapFrom(src => src.ProductTags
                        .Select(x => new ProductTagDTO { Id = x.Id, TagName = x.TagName, IsActive = x.IsActive, ProductId = x.ProductId })));


            CreateMap<Category, CategoryDTO>();
                 //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                 //.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
                
        }
    }
}
