using System.ComponentModel.DataAnnotations;

namespace Dokument_Sergej.Models
{
    public class Licnost
    {
        [Key] public int LicnostID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Funkcija { get; set; }

    }
}
