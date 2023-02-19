using AutoMapper;
using LicnostProjekat.Data.DTO;
using LicnostProjekat.Models;

namespace LicnostProjekat.Helper

{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Adresa, AdresaDTO>();
            CreateMap<AdresaDTO, Adresa>();
            CreateMap<FizickoLice, FizickoLiceDTO>();
            CreateMap<FizickoLiceDTO, FizickoLice>();
            CreateMap<KontaktOsoba, KontaktOsobaDTO>();
            CreateMap<KontaktOsobaDTO, KontaktOsoba>();
            CreateMap<Kupac, KupacDTO>();
            CreateMap<KupacDTO, Kupac>();
            CreateMap<Licnost, LicnostDTO>();
            CreateMap<LicnostDTO, Licnost>();
            CreateMap<PravnoLice, PravnoLiceDTO>();
            CreateMap<PravnoLiceDTO, PravnoLice>();

            //proba
            CreateMap<FizickoLice, FizickoLicePostDTO>();
            CreateMap<FizickoLicePostDTO, FizickoLice>();

            CreateMap<FizickoLice, FizickoLiceUpdateDTO>();
            CreateMap<FizickoLiceUpdateDTO, FizickoLice>();

            CreateMap<Licnost, LicnostUpdateDTO>();
            CreateMap<LicnostUpdateDTO, Licnost>();

            CreateMap<Licnost, LicnostPostDTO>();
            CreateMap<LicnostPostDTO, Licnost>();

            CreateMap<PravnoLice, PravnoLicePostDTO>();
            CreateMap<PravnoLicePostDTO, PravnoLice>();

            CreateMap<PravnoLice, PravnoLiceUpdateDTO>();
            CreateMap<PravnoLiceUpdateDTO, PravnoLice>();
        }
    }
}
