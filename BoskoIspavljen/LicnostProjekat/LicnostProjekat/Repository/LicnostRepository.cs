using LicnostProjekat.Data;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;
using Microsoft.EntityFrameworkCore;

namespace LicnostProjekat.Repository
{
    public class LicnostRepository : ILicnostRepository
    {
        private readonly DataContext _context;
        public LicnostRepository(DataContext context)
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

        public ICollection<Licnost> getAllLicnosts()
        {
            return _context.Licnostis.OrderBy(p => p.LicnostID).Include(x=>x.kupac).ToList();
        }

        public Licnost getLicnostByID(int id)
        {
            return _context.Licnostis.Where(p => p.LicnostID == id).Include(x => x.kupac).FirstOrDefault();
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
