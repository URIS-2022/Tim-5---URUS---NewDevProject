using Licitacija_Project.Data;
using Licitacija_Project.Interface;
using Licitacija_Project.Models;

namespace Licitacija_Project.Repository
{
    public class JavnoNadmetanjeVORepository : IJavnoNadmetanjeVORepository
    {
        private readonly DataContext _context;
        public JavnoNadmetanjeVORepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateJavnoNadmetanje(JavnoNadmetanjeVO javnoNadmetanjeVO)
        {
            _context.Add(javnoNadmetanjeVO);
            return Save();
        }

        public bool DeleteJavnoNadmetanje(JavnoNadmetanjeVO javnoNadmetanjeVO)
        {
            _context.Remove(javnoNadmetanjeVO);
            return Save();
        }

        public JavnoNadmetanjeVO GetJavnoNadmetanjeById(int id)
        {
            return _context.JavnoNadmetanjeVOs.Where(k => k.JavnoNadmetanjeID == id).FirstOrDefault();
        }

        public ICollection<JavnoNadmetanjeVO> GetJavnoNadmetanjes()
        {
            return _context.JavnoNadmetanjeVOs.OrderBy(k => k.JavnoNadmetanjeID).ToList();
        }

        public bool JavnoNadmetanjeExist(int JavnoNadmetanjeID)
        {
            return _context.JavnoNadmetanjeVOs.Any(k => k.JavnoNadmetanjeID == JavnoNadmetanjeID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateJavnoNadmetanje(JavnoNadmetanjeVO javnoNadmetanjeVO)
        {
            _context.Update(javnoNadmetanjeVO);
            return Save();
        }
    }
}
