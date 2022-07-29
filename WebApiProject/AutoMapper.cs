using AutoMapper;
using DL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap<Flight, FlightDTO>().ForMember(
                dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.Company.AirlineName))
               .ForMember(dest => dest.SourceCountry,
               opt => opt.MapFrom(src => src.SourceCountry.CountryName))
               .ForMember(dest => dest.DestinationCountry,
               opt => opt.MapFrom(src => src.DestinationCountry.CountryName))
                .ForMember(dest => dest.SourceAirport,
               opt => opt.MapFrom(src => src.SourceAirport.AirportName))
               .ForMember(dest => dest.DestinationAirport,
               opt => opt.MapFrom(src => src.DestinationAirport.AirportName))
               //.ForMember(dest => dest.Duration,
               //opt => opt.MapFrom(src => src.LandingTime-src.LeavingTime))
               .ReverseMap();

            //CustomerDTO
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CreditDetails, CreditDetailsDTO>().ReverseMap();
        }

        private object CreateMap<T1, T2>()
        {
            throw new NotImplementedException();
        }
    }
}
