using AutoMapper;
using KorisnikSistema.Models;
using KorisnikSistema.Models.DTOs;

namespace KorisnikSistema.Profiles
{
    public class TipKorisnikaProfile : Profile
    {
        public TipKorisnikaProfile()
        {
            CreateMap<TipKorisnika, TipKorisnikaDTO>();
            CreateMap<TipKorisnikaDTO, TipKorisnika>();
        }
    }
}
