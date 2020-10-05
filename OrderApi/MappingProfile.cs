using OrderApi.Models;
using OrderApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace OrderApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderCreateDTO, Orders>();
            CreateMap<Orders, OrderCreateDTO>();
            CreateMap<OrderUpdateDTO, Orders>();
            CreateMap<Orders, OrderUpdateDTO>();

        }
    }
}
