using AutoMapper;
using Dokument_Sergej.Data.DTO;
using Dokument_Sergej.Models;

namespace Dokument_Sergej.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Dokument, DokumentDTO>();
            CreateMap<DokumentDTO, Dokument>();

            CreateMap<KorisnikSistema, KorisnikSistemaDTO>();
            CreateMap<KorisnikSistemaDTO, KorisnikSistema>();   

            CreateMap<Licnost,LicnostDTO>();
            CreateMap<LicnostDTO, Licnost>();

            CreateMap<Dokument, DokumentDTOCreate>();
            CreateMap<DokumentDTOCreate, Dokument>();

            CreateMap<Dokument, DokumentDTOUpdate>();
            CreateMap<DokumentDTOUpdate, Dokument>();

        }
    }
}
