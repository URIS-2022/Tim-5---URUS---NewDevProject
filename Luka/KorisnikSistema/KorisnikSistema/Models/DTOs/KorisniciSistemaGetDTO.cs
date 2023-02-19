namespace KorisnikSistema.Models.DTOs
{
    public class KorisniciSistemaGetDTO
    {
        public int KorisnikSistemaID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Lozinka { get; set; }

        public List<TipKorisnika> ListaTipovaKorisnika { get; set; }

        public KorisniciSistemaGetDTO()
        {

        }

        public KorisniciSistemaGetDTO(KorisniciSistema korisniciSistema)
        {
            KorisnikSistemaID = korisniciSistema.KorisnikSistemaID;
            Ime = korisniciSistema.Ime;
            Prezime = korisniciSistema.Prezime;
            ListaTipovaKorisnika = korisniciSistema.ListaTipovaKorisnika;
        }
    }
}
