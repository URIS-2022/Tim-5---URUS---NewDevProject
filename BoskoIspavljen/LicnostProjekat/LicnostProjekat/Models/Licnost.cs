using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostProjekat.Models
{
    public class Licnost
    {
        [Key]
        public int LicnostID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Funkcija { get; set; }
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac kupac { get; set; }

    }
}
