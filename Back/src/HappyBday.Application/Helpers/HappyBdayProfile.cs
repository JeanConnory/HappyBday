using AutoMapper;
using HappyBday.Application.Dtos;
using HappyBday.Domain;

namespace HappyBday.API.Helpers
{
    public class HappyBdayProfile : Profile
    {
        public HappyBdayProfile()
        {
            CreateMap<Aniversario, AniversarioDto>().ReverseMap();
            CreateMap<Parentesco, ParentescoDto>().ReverseMap();
        }
    }
}