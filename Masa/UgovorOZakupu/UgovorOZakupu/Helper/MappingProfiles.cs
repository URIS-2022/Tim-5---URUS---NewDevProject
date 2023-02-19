using AutoMapper;
using UgovorOZakupu.Models;
using UgovorOZakupu.Models.DTOs;

namespace UgovorOZakupu.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Models.UgovorOZakupu, UgovorOZakupudto>();
            CreateMap<UgovorOZakupudto, Models.UgovorOZakupu>();

            CreateMap<LicnostVO, LicnostVOdto>();
            CreateMap<LicnostVOdto, LicnostVO>();

            CreateMap<KupacVO, KupacVOdtos>();
            CreateMap<KupacVOdtos, KupacVO>();

            CreateMap<JavnoNadmetanjeVO, JavnoNadmetanjeVOdto>();
            CreateMap<JavnoNadmetanjeVOdto, JavnoNadmetanjeVO>();

            CreateMap<DokumentVO, DokumentVOdto>();
            CreateMap<DokumentVOdto, DokumentVO>();

            CreateMap<UgovorOZakupuDTOCreate, Models.UgovorOZakupu>();
            CreateMap<Models.UgovorOZakupu, UgovorOZakupuDTOCreate>();

            CreateMap<Models.UgovorOZakupu, UgovorOZakupuDTOUpdate>();
            CreateMap<UgovorOZakupuDTOUpdate, Models.UgovorOZakupu>();
        }
    }
}
