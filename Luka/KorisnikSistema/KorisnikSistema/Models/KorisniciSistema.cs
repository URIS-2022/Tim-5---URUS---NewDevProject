using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KorisnikSistema.Models
{
    public class KorisniciSistema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikSistemaID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Lozinka { get; set; }

        public List<TipKorisnika> ListaTipovaKorisnika { get; set; }


    }
}
