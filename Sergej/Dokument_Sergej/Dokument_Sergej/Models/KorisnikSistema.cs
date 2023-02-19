using System.ComponentModel.DataAnnotations;

namespace Dokument_Sergej.Models
{
    public class KorisnikSistema
    {
        [Key] public int KorisnikSistemaID { get; set; }
        
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
