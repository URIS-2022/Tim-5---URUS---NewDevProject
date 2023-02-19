using JavnoNadPavle.Data;
using JavnoNadPavle.Interfaces;
using JavnoNadPavle.Models;
using Microsoft.EntityFrameworkCore;

namespace JavnoNadPavle.Repository
{
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly DataContext _context;

        public JavnoNadmetanjeRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje)
        {
            _context.Add(javnoNadmetanje);
            return Save();
        }

        public bool DeleteJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje)
        {
            _context.Remove(javnoNadmetanje);
            return Save();
        }

        public ICollection<JavnoNadmetanje> GetJavnaNadmetanja()
        {
            return _context.JavnaNadmetanja.OrderBy(p => p.JavnoNadmetanjeID)
              .ToList();

            throw new NotImplementedException();
        }

        public JavnoNadmetanje GetJavnaNadmetanje(int id)
        {
            return _context.JavnaNadmetanja.Where(p => p.JavnoNadmetanjeID == id)
                .Include(x => x.Nadmetanje).Include(x => x.Etapa).FirstOrDefault();
            throw new NotImplementedException();
        }

        public bool JavnoNadmetanjeExists(int nadId)
        {
            return _context.JavnaNadmetanja.Any(p => p.JavnoNadmetanjeID == nadId);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje)
        {
            _context.Update(javnoNadmetanje);
            return Save();
        }
    }
}
