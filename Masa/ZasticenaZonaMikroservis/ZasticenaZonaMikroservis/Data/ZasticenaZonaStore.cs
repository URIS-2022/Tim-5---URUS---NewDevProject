using ZasticenaZonaMikroservis.Models.DTO;

namespace ZasticenaZonaMikroservis.Data
{
    public static class ZasticenaZonaStore
    {
        public static List<ZasticenaZonaDTO> ZasticenaZonaList = new List<ZasticenaZonaDTO>{
            new ZasticenaZonaDTO{ ZasticenaZonaID= 2,
                           DozvoljeniRadovi = "kopanje",
                           StepenZastite = 1,
                           VrstaZasticenogPodrucja = "reka"},
            new ZasticenaZonaDTO{ZasticenaZonaID = 4,
                                DozvoljeniRadovi = "gradnja igralista",
                                StepenZastite = 2,
                                VrstaZasticenogPodrucja = "Strand"}
            };
    }
}
