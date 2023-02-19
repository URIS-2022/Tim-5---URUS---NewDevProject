using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostProjekat.Models
{
    public class FizickoLice
    {
        [Key]
        public int FizickoLiceID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String JMBG { get; set; }
        public String BrojTelefona1 { get; set; }
        public String BrojTelefona2 { get; set; }
        public String Email { get; set; }
        public String BrojRacuna { get; set; }
        [ForeignKey("Adresa")]
        public int AdresaID { get; set; }
        public Adresa adresa { get; set; }
        [ForeignKey("KontaktOsoba")]
        public int KontaktOsobaID { get; set; }
        public KontaktOsoba KontaktOsoba { get; set; }
        [ForeignKey("Licnost")]
        public int LicnostID { get; set; }
        public Licnost Licnost { get; set; }

    }
}
