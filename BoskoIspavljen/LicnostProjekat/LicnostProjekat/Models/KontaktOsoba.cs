using System.ComponentModel.DataAnnotations;

namespace LicnostProjekat.Models
{
    public class KontaktOsoba
    {
        [Key]
        public int KontaktOsobaID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Funkcija { get; set; }
        public String Telefon { get; set; }

    }
}
