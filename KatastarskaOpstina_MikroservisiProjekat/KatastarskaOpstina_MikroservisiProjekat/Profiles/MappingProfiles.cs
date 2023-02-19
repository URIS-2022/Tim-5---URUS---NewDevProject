using AutoMapper;
using KatastarskaOpstina_MikroservisiProjekat.Models;
using KatastarskaOpstina_MikroservisiProjekat.Models.ModelsDto;

namespace KatastarskaOpstina_MikroservisiProjekat.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaDto>();
            CreateMap<KatastarskaOpstinaDto, KatastarskaOpstina>();

            CreateMap<StatutOpstine, StatutOpstineDto>();
            CreateMap<StatutOpstineDto, StatutOpstine>();

            CreateMap<StatutOpstine, StatutOpstineDtoCreate>();
            CreateMap<StatutOpstineDtoCreate, StatutOpstine>();

            CreateMap<StatutOpstineDtoUpdate, StatutOpstine>();
            CreateMap<StatutOpstine, StatutOpstineDtoUpdate>();
        }
    }
}
