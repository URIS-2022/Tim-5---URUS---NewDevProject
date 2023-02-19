using System.ComponentModel.DataAnnotations.Schema;

namespace Kupac__Mikroservis.Models.DTO
{
    public class OvlascenoLiceDTOCreate
    {
        public int OvlascenoLiceID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG_BrojPasosa { get; set; }
        public string Drazava { get; set; }
        public int BrojTabele { get; set; }

        public int AdresaID { get; set; }

    }
}
