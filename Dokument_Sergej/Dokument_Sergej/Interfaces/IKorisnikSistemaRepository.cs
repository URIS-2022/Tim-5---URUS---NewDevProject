using Dokument_Sergej.Models;

namespace Dokument_Sergej.Interfaces
{
    public interface IKorisnikSistemaRepository
    {
        ICollection<KorisnikSistema> GetKorisniciSistema();
        KorisnikSistema GetKorisnikSistemaByID(int id);
        bool CreateKorisnikSistema(KorisnikSistema korisnik);
        bool Save();
        bool UpdateKorisnikSistema(KorisnikSistema korisnik);
        bool DeleteKorisnikSistema(KorisnikSistema korisnik);
        bool KorisnikSistemaExsists(int id);

    }
}
