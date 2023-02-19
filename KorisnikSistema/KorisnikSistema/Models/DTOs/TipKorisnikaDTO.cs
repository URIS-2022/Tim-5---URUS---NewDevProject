using System.ComponentModel.DataAnnotations;

namespace KorisnikSistema.Models.DTOs
{
    /// <summary>
    /// Predstavlja model tipa korisnika
    /// </summary>
    public class TipKorisnikaDTO
    {
        [Key]

        public int TipKorisnikaID { get; set; }

        public string NazivTipaKorisnika { get; set; }
    }
}
