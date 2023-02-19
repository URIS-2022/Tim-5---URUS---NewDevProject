using Komisija_Sergej.Data;
using Komisija_Sergej.Interfaces;
using Komisija_Sergej.Models;

namespace Komisija_Sergej.Repository
{
    public class KomisijaRepository : IKomisijaRepository
    {

        private readonly DataContext _context;
        public KomisijaRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateKomisija(Komisija komisija)
        {
            _context.Add(komisija);
            return Save();
        }

        public bool DeleteKomisija(Komisija komisija)
        {
            _context.Remove(komisija);
            return Save();
        }

        public Komisija GetKomisijaByID(int id)
        {
            return _context.Komisije.Where(p => p.KomisijaID == id).FirstOrDefault();
        }

        public ICollection<Komisija> GetKomisijas()
        {
            return _context.Komisije.OrderBy(p => p.KomisijaID).ToList();
        }

        public bool KomisijaExsists(int id)
        {
            return _context.Komisije.Any(p => p.KomisijaID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateKomisija(Komisija komisija)
        {
            _context.Update(komisija);
            return Save();
        }
    }
}
