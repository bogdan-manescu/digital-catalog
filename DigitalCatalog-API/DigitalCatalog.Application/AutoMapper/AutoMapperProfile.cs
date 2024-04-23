using AutoMapper;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Domain.Models;

namespace DigitalCatalog.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
        }
    }
}
