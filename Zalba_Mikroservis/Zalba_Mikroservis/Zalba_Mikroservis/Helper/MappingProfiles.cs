using AutoMapper;
using Zalba_Mikroservis.Models;
using Zalba_Mikroservis.Models.DTO;

namespace Zalba_Mikroservis.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Zalba, ZalbaDTO>();
            CreateMap<ZalbaDTO, Zalba>();
            CreateMap<KupacVO, KupacVODTO>();
            CreateMap<KupacVODTO, KupacVO>();
            CreateMap<Zalba, ZalbaDTOUpdate>();
            CreateMap<ZalbaDTOUpdate, Zalba>();
            CreateMap<Zalba, ZalbaDTOCreate>();
            CreateMap<ZalbaDTOCreate, Zalba>();
        }
    }
}
