using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kupac__Mikroservis.Models
{
    public class Uplata
    {
        [Key]
        public int UplataID { get; set; }
        public string BrojRacuna { get; set; }
        public string PozivNaBroj { get; set; }
        public double Iznos { get; set; }
        public string Uplatilac { get; set; }
        public string SvrhaUplate { get; set; }
        public DateTime Datum { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }

        public Kupac Kupac { get; set; }

    }
}
