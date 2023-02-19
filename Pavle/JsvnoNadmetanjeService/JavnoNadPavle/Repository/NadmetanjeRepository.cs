using JavnoNadPavle.Data;
using JavnoNadPavle.Interfaces;
using JavnoNadPavle.Models;

namespace JavnoNadPavle.Repository
{
    public class NadmetanjeRepository : INadmetanjeRepository
    {
        private readonly DataContext _context;

        public NadmetanjeRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNadmetanje(Nadmetanje nadmetanje)
        {
            //Change Tracker
            _context.Add(nadmetanje);
            return Save();
        }

        public bool DeleteNadmetanje(Nadmetanje nadmetanje)
        {
            _context.Remove(nadmetanje);
            return Save();
        }

        public ICollection<Nadmetanje> GetNadmetanja()
        {
            return _context.Nadmetanja.OrderBy(p => p.NadmetanjeID).ToList();
        }

        public Nadmetanje GetNadmetanje(int id)
        {
            return _context.Nadmetanja.Where(p => p.NadmetanjeID == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public bool NadmetanjeExists(int nadId)
        {
            return _context.Nadmetanja.Any(p => p.NadmetanjeID != nadId);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateNadmetanje(Nadmetanje nadmetanje)
        {
            _context.Update(nadmetanje);
            return Save();
        }
    }
}
