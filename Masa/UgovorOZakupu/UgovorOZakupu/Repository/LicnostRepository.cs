using Microsoft.EntityFrameworkCore;
using UgovorOZakupu.Data;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models;

namespace UgovorOZakupu.Repository
{
    public class LicnostRepository : ILicnostRepository
    {
        private readonly ApplicationContext _context;
        public LicnostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public LicnostRepository()
        {

        }
        public bool CreateLicnost(LicnostVO licnostMap)
        {
            _context.Add(licnostMap);
            return Save();
            throw new NotImplementedException();
        }

        public bool DeleteLicnost(LicnostVO licnost)
        {
            _context.Remove(licnost);
            return Save();
            throw new NotImplementedException();
        }

        public LicnostVO GetLicnostByID(int id)
        {
            return _context.Licnosti.Where(p => p.LicnostID == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public ICollection<LicnostVO> GetLicnosti()
        {
            return _context.Licnosti.OrderBy(p => p.LicnostID).ToList();
            throw new NotImplementedException();
        }

        public bool LicnostExsists(int id)
        {
            return _context.Licnosti.Any(p => p.LicnostID == id);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateLicnost(LicnostVO licnost)
        {
            _context.Update(licnost);
            return Save();
            throw new NotImplementedException();
        }
    }
}
