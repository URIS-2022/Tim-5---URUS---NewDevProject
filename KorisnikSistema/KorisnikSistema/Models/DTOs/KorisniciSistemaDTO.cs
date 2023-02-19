using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KorisnikSistema.Models.DTOs
{
    /// <summary>
    /// Predstavlja model korisnika sistema
    /// </summary>
    public class KorisniciSistemaDTO
    {
        public int KorisnikSistemaID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Lozinka { get; set; }

        public List<int> ListaTipovaKorisnika { get; set; }

        public KorisniciSistemaDTO()
        {

        }
    }
}
