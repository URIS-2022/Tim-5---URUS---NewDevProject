using LicnostProjekat.Data;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;

namespace LicnostProjekat.Repository
{
    public class PravnoLiceRepository : IPravnoLiceRepository
    {
        private readonly DataContext _context;
        public PravnoLiceRepository(DataContext context) { 
        _context= context;
        }

        public bool CreatePravnoLice(PravnoLice pravnoLice)
        {
            _context.Add(pravnoLice);
            return Save();
        }

        public bool DeletePravnoLice(PravnoLice pravnoLice)
        {
            _context.Remove(pravnoLice);
            return Save();
        }

        public ICollection<PravnoLice> getPravnaLica()
        {
            return _context.PravnaLicas.OrderBy(p => p.PravnoLiceID).ToList();
        }

        public PravnoLice getPravnoLiceByID(int id)
        {
            return _context.PravnaLicas.Where(p => p.PravnoLiceID == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePravnoLice(PravnoLice pravnoLice)
        {
            _context.Update(pravnoLice);
            return Save();
        }
    }
}
