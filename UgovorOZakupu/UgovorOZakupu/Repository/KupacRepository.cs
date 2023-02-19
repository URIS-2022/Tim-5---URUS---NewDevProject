using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models;
using Microsoft.EntityFrameworkCore;
using UgovorOZakupu.Data;

namespace UgovorOZakupu.Repository
{
    public class KupacRepository : IKupacRepository
    {
        private readonly ApplicationContext _context;
        public KupacRepository(ApplicationContext context)
        {
            _context = context;
        }
        public KupacRepository()
        {

        }
        public bool CreateKupac(KupacVO kupacMap)
        {
            _context.Add(kupacMap);
            return Save();
            throw new NotImplementedException();
        }

        public bool DeleteKupac(KupacVO kupac)
        {
            _context.Remove(kupac);
            return Save();
            throw new NotImplementedException();
        }

        public KupacVO GetKupacByID(int id)
        {
            return _context.Kupci.Where(p => p.KupacID == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public ICollection<KupacVO> GetKupci()
        {
            return _context.Kupci.OrderBy(p => p.KupacID).ToList();
            throw new NotImplementedException();
        }

        public bool KupacExsists(int id)
        {
            return _context.Kupci.Any(p => p.KupacID == id);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateKupac(KupacVO kupac)
        {
            _context.Update(kupac);
            return Save();
            throw new NotImplementedException();
        }
    }
}
