using AutoMapper;
using Domain.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResultDto>()
                .ReverseMap();

            // For creating a new order using product IDs
            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.Products, opt => opt.Ignore()); // We'll assign products manually
        }
    }
}
