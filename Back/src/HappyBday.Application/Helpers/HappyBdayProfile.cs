using AutoMapper;
using HappyBday.Application.Dtos;
using HappyBday.Domain;
using HappyBday.Domain.Identity;

namespace HappyBday.API.Helpers
{
    public class HappyBdayProfile : Profile
    {
        public HappyBdayProfile()
        {
            CreateMap<Aniversario, AniversarioDto>().ReverseMap();
            CreateMap<Parentesco, ParentescoDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}