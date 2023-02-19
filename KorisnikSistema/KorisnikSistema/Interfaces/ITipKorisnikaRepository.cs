using KorisnikSistema.Data1;
using KorisnikSistema.Models;

namespace KorisnikSistema.Interfaces
{
    public interface ITipKorisnikaRepository : IBaseRepository<int, TipKorisnika>
    {
        IEnumerable<TipKorisnika> GetAll();
    }
}
