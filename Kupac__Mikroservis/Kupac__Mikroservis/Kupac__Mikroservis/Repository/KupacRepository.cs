using Kupac__Mikroservis.Data;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Microsoft.EntityFrameworkCore;

namespace Kupac__Mikroservis.Repository
{
    public class KupacRepository : IKupacRepository
    {

        private readonly DataContext _context;
        public KupacRepository(DataContext context)
        {
            _context = context;
        }

        //POST
        public bool CreateKupac(Kupac kupac)
        {
            _context.Add(kupac);
            _context.SaveChanges();
            return Save();
            throw new NotImplementedException();
        }

        //DELETE
        public bool DeleteKupac(Kupac kupac)
        {
            _context.Remove(kupac);
            return Save();
        }

        //GETBYID
        public Kupac GetKupacById(int id)
        {
            return _context.Kupacs.Where(k => k.KupacID == id)
                .Include(x => x.OvlascenoLice)
                .FirstOrDefault();
            throw new NotImplementedException();
        }

        //GETALL
        public ICollection<Kupac> GetKupacs()
        {
            return _context.Kupacs.OrderBy(k => k.KupacID)
                .Include(x => x.OvlascenoLice)
                .ToList();
            throw new NotImplementedException();
        }

        //EXIST
        public bool KupacExist(int KupId)
        {
            return _context.Kupacs.Any(k => k.KupacID == KupId);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        //PUT
        public bool UpdateKupac(Kupac kupac)
        {
            _context.Update(kupac);
            return Save();
            throw new NotImplementedException();
        }
    }
}
