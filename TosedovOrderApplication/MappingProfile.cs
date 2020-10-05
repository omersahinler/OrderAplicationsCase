using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TosedovOrderApplication.Models;
using TosedovOrderApplication.Models.DTO;

namespace TosedovOrderApplication
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerCreateDTO, Customers>();
            CreateMap<Customers, CustomerCreateDTO>();
            CreateMap<CustomerUpdateDTO, Customers>();
            CreateMap<Customers, CustomerUpdateDTO>();
          
        }
    }
}
