using LicnostProjekat.Data;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;

namespace LicnostProjekat.Repository
{
    public class KontaktOsobaRepository : IKontaktOsobaRepository
    {
        private readonly DataContext _context;
        public KontaktOsobaRepository (DataContext context)
        {
            _context = context;
        }

        public bool CreateKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            _context.Add(kontaktOsoba);
            return Save();
        }

        public bool DeleteKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            _context.Remove(kontaktOsoba);
            return Save();
        }

        public KontaktOsoba getKontaktOsobaByID(int id)
        {
            return _context.KontaktOsobas.Where(p => p.KontaktOsobaID == id).FirstOrDefault();
        }

        public ICollection<KontaktOsoba> GetKontaktOsobas()
        {
            return _context.KontaktOsobas.OrderBy(p => p.KontaktOsobaID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true:false;
        }

        public bool UpdateKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            _context.Update(kontaktOsoba);
            return Save();
        }
    }
}
