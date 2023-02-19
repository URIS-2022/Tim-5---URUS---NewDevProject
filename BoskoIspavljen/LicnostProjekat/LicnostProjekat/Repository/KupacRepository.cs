using LicnostProjekat.Data;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;

namespace LicnostProjekat.Repository
{
    public class KupacRepository : IKupacRepository
    {
        private readonly DataContext _context;
        public KupacRepository(DataContext context)
        {
            _context = context;
        }
public ICollection<Kupac> GetKupci()
        {
            return _context.Kupcis.OrderBy(p => p.KupacID).ToList();
        }

        public Kupac GetKupacByID(int id)
        {
            return _context.Kupcis.Where(p => p.KupacID == id).FirstOrDefault();
        }

        public bool CreateKupac(Kupac kupac)
        {
            _context.Add(kupac);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateKupac(Kupac kupac)
        {
            _context.Update(kupac);
            return Save();
        }

        public bool DeleteKupac(Kupac kupac)
        {
            _context.Remove(kupac);
            return Save();
        }
    }
}
