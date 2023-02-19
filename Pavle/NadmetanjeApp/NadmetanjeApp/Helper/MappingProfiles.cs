using AutoMapper;
using NadmetanjeApp.Dto;
using NadmetanjeApp.Models;

namespace NadmetanjeApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Nadmetanje, NadmetanjeDto>();
            CreateMap<NadmetanjeDto, Nadmetanje>();
            CreateMap<OtvaranjePonude, OtvaranjePonudeDto>();
            CreateMap<OtvaranjePonudeDto, OtvaranjePonude>();
            CreateMap<OtvaranjePonude, OtvaranjePonudeCreateDTO>();
            CreateMap<OtvaranjePonudeCreateDTO, OtvaranjePonude>();
            CreateMap<OtvaranjePonude, OtvaranjePonudeUpdateDTO>();
            CreateMap<OtvaranjePonudeUpdateDTO, OtvaranjePonude>();
        }
    }
}
