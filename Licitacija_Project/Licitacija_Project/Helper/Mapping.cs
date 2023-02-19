using AutoMapper;
using Licitacija_Project.Models;
using Licitacija_Project.Models.DTO;

namespace Licitacija_Project.Helper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DokumentVO, DokumentVODTO>();
            CreateMap<DokumentVODTO, DokumentVO>();
            CreateMap<JavnoNadmetanjeVO, JavnoNadmetanjeVODTO>();
            CreateMap<JavnoNadmetanjeVODTO, JavnoNadmetanjeVO>();
            CreateMap<Licitacija, LicitacijaDTO>();
            CreateMap<LicitacijaDTO, Licitacija>();

            CreateMap<Licitacija, LicitacijaCreateDTO>();
            CreateMap<LicitacijaCreateDTO, Licitacija>();

        }
    }
}