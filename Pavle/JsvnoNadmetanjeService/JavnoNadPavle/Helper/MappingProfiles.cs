using AutoMapper;
using JavnoNadPavle.Dto;
using JavnoNadPavle.Models;

namespace JavnoNadPavle.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Nadmetanje, NadmetanjeDto>();
            CreateMap<NadmetanjeDto, Nadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeDto>();
            CreateMap<JavnoNadmetanjeDto, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeCreateDTO>();
            CreateMap<JavnoNadmetanjeCreateDTO, JavnoNadmetanje>();
            CreateMap<JavnoNadmetanje, JavnoNadmetanjeUpdateDTO>();
            CreateMap<JavnoNadmetanjeUpdateDTO, JavnoNadmetanje>();
        }
    }
}
