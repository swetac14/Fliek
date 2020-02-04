using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Fliek.Models;
using Fliek.Dtos;

namespace Fliek.App_Start
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}