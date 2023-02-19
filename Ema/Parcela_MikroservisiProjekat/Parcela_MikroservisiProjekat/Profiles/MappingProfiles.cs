using AutoMapper;
using Parcela_MikroservisiProjekat.Models;
using Parcela_MikroservisiProjekat.Models.ModelsDto;

namespace Parcela_MikroservisiProjekat.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Parcela, ParcelaDto>();
            CreateMap<ParcelaDto, Parcela>();

            CreateMap<KatastarskaOpstinaVO, KatastarskaOpstinaVODto>();
            CreateMap<KatastarskaOpstinaVODto, KatastarskaOpstinaVO>();

            CreateMap<DeoParcele, DeoParceleDto>();
            CreateMap<DeoParceleDto, DeoParcele>();

            CreateMap<Parcela, ParcelaDtoCreate>();
            CreateMap<ParcelaDtoCreate, Parcela>();

            CreateMap<ParcelaDtoUpdate, Parcela>();
            CreateMap<Parcela, ParcelaDtoUpdate>();
        }
    }
}
