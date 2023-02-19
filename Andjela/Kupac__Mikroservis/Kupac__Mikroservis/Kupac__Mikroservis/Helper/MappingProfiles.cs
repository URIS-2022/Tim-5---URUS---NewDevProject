using AutoMapper;
using Kupac__Mikroservis.Models;
using Kupac__Mikroservis.Models.DTO;

namespace Kupac__Mikroservis.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AdresaVO, AdresaVODTO>();
            CreateMap<AdresaVODTO, AdresaVO>();
            CreateMap<Kupac, KupacDTO>();
            CreateMap<KupacDTO, Kupac>();
            CreateMap<OvlascenoLice, OvlascenoLiceDTO>();
            CreateMap<OvlascenoLiceDTO, OvlascenoLice>();
            CreateMap<Uplata, UplataDTO>();
            CreateMap<UplataDTO, Uplata>();
            CreateMap<Uplata, UplataDTOCreate>();
            CreateMap<UplataDTOCreate, Uplata>();
            CreateMap<Uplata, UplataDTOUpdate>();
            CreateMap<UplataDTOUpdate, Uplata>();
            CreateMap<Kupac, KupacDTOCreate>();
            CreateMap<KupacDTOCreate, Kupac>();
            CreateMap<Kupac, KupacDTOUpdate>();
            CreateMap<KupacDTOUpdate, Kupac>();
            CreateMap<OvlascenoLice, OvlascenoLiceDTOCreate>();
            CreateMap<OvlascenoLiceDTOCreate, OvlascenoLice>();
            CreateMap<OvlascenoLice, OvlascenoLiceDTOUpdate>();
            CreateMap<OvlascenoLiceDTOUpdate, OvlascenoLice>();
        }
    }
}
