using KorisnikSistema.Data1;
using KorisnikSistema.Interfaces;
using KorisnikSistema.Models;

namespace KorisnikSistema.Repository
{
    public class TipKorisnikaRepository : BaseRepository<int, TipKorisnika>, ITipKorisnikaRepository
    {
        private readonly DataContext _context;
        public TipKorisnikaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<TipKorisnika> GetAll()
        {
            return _context.TipKorisnikas.ToList();
        }

    }
}
