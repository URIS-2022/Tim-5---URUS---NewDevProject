using Dokument_Sergej.Data;
using Dokument_Sergej.Interfaces;
using Dokument_Sergej.Models;

namespace Dokument_Sergej.Repository
{
    public class KorisnikSistemaRepository : IKorisnikSistemaRepository
    {
        private readonly DataContext _context;
        public KorisnikSistemaRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateKorisnikSistema(KorisnikSistema korisnik)
        {
            _context.Add(korisnik);
            return Save();
        }

        public bool DeleteKorisnikSistema(KorisnikSistema korisnik)
        {
            _context.Remove(korisnik);
            return Save();
        }

        public ICollection<KorisnikSistema> GetKorisniciSistema()
        {
            return _context.KorisniciSistema.OrderBy(p => p.KorisnikSistemaID).ToList();
        }

        public KorisnikSistema GetKorisnikSistemaByID(int id)
        {
            return _context.KorisniciSistema.Where(p => p.KorisnikSistemaID == id).FirstOrDefault();
        }

        public bool KorisnikSistemaExsists(int id)
        {
            return _context.KorisniciSistema.Any(p => p.KorisnikSistemaID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateKorisnikSistema(KorisnikSistema korisnik)
        {
            _context.Update(korisnik);
            return Save();
        }
    }
}
