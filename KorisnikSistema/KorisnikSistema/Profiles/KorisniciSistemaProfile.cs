using KorisnikSistema.Models.DTOs;
using KorisnikSistema.Models;
using AutoMapper;

namespace KorisnikSistema.Profiles
{
    public class KorisniciSistemaProfile : Profile
    {
        public KorisniciSistemaProfile()
        {
            CreateMap<KorisniciSistema, KorisniciSistemaDTO>();
            CreateMap<KorisniciSistemaDTO, KorisniciSistema>();
        }
    }
}
