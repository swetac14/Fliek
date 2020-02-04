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
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}