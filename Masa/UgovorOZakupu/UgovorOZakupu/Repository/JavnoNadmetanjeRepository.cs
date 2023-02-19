using UgovorOZakupu.Data;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models;

namespace UgovorOZakupu.Repository
{
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly ApplicationContext _context;
        public JavnoNadmetanjeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public JavnoNadmetanjeRepository()
        {

        }
        public bool CreateJavnoNadmetanje(JavnoNadmetanjeVO javnonadmetanjeMap)
        {
            _context.Add(javnonadmetanjeMap);
            return Save();
            throw new NotImplementedException();
        }

        public bool DeleteJavnoNadmetanje(JavnoNadmetanjeVO javnonadmetanje)
        {
            _context.Remove(javnonadmetanje);
            return Save();
            throw new NotImplementedException();
        }

        public ICollection<JavnoNadmetanjeVO> GetJavnaNadmetanja()
        {
            return _context.JavnaNadmetanja.OrderBy(p => p.JavnoNadmetanjeID).ToList();
            throw new NotImplementedException();
        }

        public JavnoNadmetanjeVO GetJavnoNadmetanjeByID(int id)
        {
            return _context.JavnaNadmetanja.Where(p => p.JavnoNadmetanjeID == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public bool JavnoNadmetanjeExsists(int id)
        {
            return _context.JavnaNadmetanja.Any(p => p.JavnoNadmetanjeID == id);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateJavnoNadmetanje(JavnoNadmetanjeVO javnonadmetanje)
        {
            _context.Update(javnonadmetanje);
            return Save();
            throw new NotImplementedException();
        }
    }
}
