using Microsoft.EntityFrameworkCore;
using NadmetanjeApp.Data;
using NadmetanjeApp.Interfaces;
using NadmetanjeApp.Models;

namespace NadmetanjeApp.Repository
{
    public class OtvaranjePonudeRepository : IOtvaranjePonudeRepository
    {
        private readonly DataContext _context;

        public OtvaranjePonudeRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOtvaranjePonude(OtvaranjePonude otvaranjePonude)
        {

            _context.Add(otvaranjePonude);
            return Save();
            
        }

        public bool DeleteOtvaranjePonude(OtvaranjePonude otvaranjePonude)
        {
            _context.Remove(otvaranjePonude);
            return Save();
        }

        public ICollection<OtvaranjePonude> GetOtvaranjePonuda()
        {
            return _context.OtvaranjePonuda.OrderBy(p => p.OtvaranjePonudeID).ToList();

            throw new NotImplementedException();
        }
        

        public OtvaranjePonude GetOtvaranjePonude(int id)
        {
            return _context.OtvaranjePonuda.Where(p => p.OtvaranjePonudeID == id)
                .Include(x => x.Nadmetanje).FirstOrDefault();

            throw new NotImplementedException();
        }

        

        public bool OtvaranjePonudeExists(int opId)
        {
            return _context.OtvaranjePonuda.Any(p => p.OtvaranjePonudeID != opId);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateOtvaranjePonude(OtvaranjePonude otvaranjePonude)
        {
            _context.Update(otvaranjePonude);
            return Save();
        }
    }
}
