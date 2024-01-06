using AutoMapper;
using StockApp.Application.DTOS;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, ApplicationUser>().ReverseMap();

            CreateMap<Stock, StockDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();


        }
    }
}
