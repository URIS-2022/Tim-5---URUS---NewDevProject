using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kupac__Mikroservis.Models
{
    public class OvlascenoLice
    {
        [Key]
        public int OvlascenoLiceID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG_BrojPasosa { get; set; }
        public string Drazava { get; set; }
        public int BrojTabele { get; set; }

        [ForeignKey("AdresaVO")]
        public int AdresaID { get; set; }

        public AdresaVO Adresa { get; set; }

    }
}
