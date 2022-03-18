using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Category;
using WebApiPixel.Contracts.Order;
using WebApiPixel.Contracts.Ware;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Mapper.Mapping
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Ware, WareDto>()
                .ForMember(destination => destination.Category, source => source.MapFrom(w => w.Category.Title));

            CreateMap<WareDto, Ware>();

            CreateMap<Category, CategoryDto>()
                .ForMember(destination => destination.WaresDto, source => source.MapFrom(w => w.Wares));

            CreateMap<CategoryDto, Category>();

            CreateMap<Order, OrderDto>()
                .ForMember(destination => destination.Ware, source => source.MapFrom(w => w.Ware.Title));

            CreateMap<OrderDto, Order>();


        }
    }
}
