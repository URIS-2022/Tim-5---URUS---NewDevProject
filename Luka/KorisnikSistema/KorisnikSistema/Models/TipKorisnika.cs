using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KorisnikSistema.Models
{
    public class TipKorisnika
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipKorisnikaID { get; set; }

        public string NazivTipaKorisnika { get; set; }

    }
}
