using System.ComponentModel.DataAnnotations;

namespace LicnostProjekat.Models
{
    public class Adresa
    {
        [Key] public int AdresaID { get; set; }
        public String Ulica { get; set; }
        public String Broj { get; set; }
        public String Mesto { get; set; }
        public String PostanskiBroj { get; set; }
        public String Drzava { get; set; }
    }
}
