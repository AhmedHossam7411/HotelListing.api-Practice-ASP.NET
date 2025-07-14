using AutoMapper;
using HotelListing.api.data;
using HotelListing.api.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelListing.API.NET5.Configurations
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            /*CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();*/

            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}