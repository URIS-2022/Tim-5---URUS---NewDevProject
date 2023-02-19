using AutoMapper;
using Komisija_Sergej.Data.DTO;
using Komisija_Sergej.Models;

namespace Dokument_Sergej.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Komisija, KomisijaDTO>();
            CreateMap<KomisijaDTO, Komisija>();
        

        }
    }
}
