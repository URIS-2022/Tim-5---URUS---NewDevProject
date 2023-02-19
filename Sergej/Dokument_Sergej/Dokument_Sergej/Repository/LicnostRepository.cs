using Dokument_Sergej.Data;
using Dokument_Sergej.Interfaces;
using Dokument_Sergej.Models;

namespace Dokument_Sergej.Repository
{
    public class LicnostRepository : ILicnostRepository
    {
        private readonly DataContext _context;
        public LicnostRepository (DataContext context)
        {
            _context = context;
        }

        public bool CreateLicnost(Licnost licnost)
        {
            _context.Add(licnost);
            return Save();
        }

        public bool DeleteLicnost(Licnost licnost)
        {
            _context.Remove(licnost);
            return Save();
        }

        public Licnost GetLicnostByID(int id)
        {
            return _context.Licnosti.Where(p => p.LicnostID == id).FirstOrDefault();
        }

        public ICollection<Licnost> GetLicnosti()
        {
            return _context.Licnosti.OrderBy(p => p.LicnostID).ToList();
        }

        public bool LicnostExsists(int id)
        {
            return _context.Licnosti.Any(p => p.LicnostID == id);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLicnost(Licnost licnost)
        {
            _context.Update(licnost);
            return Save();
        }
    }
}
