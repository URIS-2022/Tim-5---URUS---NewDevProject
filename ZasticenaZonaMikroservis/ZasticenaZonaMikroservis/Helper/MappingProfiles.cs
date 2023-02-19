using AutoMapper;
using ZasticenaZonaMikroservis.Models;
using ZasticenaZonaMikroservis.Models.DTO;

namespace ZasticenaZonaMikroservis.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ZasticenaZona, ZasticenaZonaDTO>();
            CreateMap<ZasticenaZonaDTO, ZasticenaZona>();
        }
    }
}
