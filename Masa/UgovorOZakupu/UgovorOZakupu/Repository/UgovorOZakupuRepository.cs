using Microsoft.EntityFrameworkCore;
using UgovorOZakupu.Data;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models;
using UgovorOZakupu.Models.DTOs;

namespace UgovorOZakupu.Repository
{
    public class UgovorOZakupuRepository : IUgovorOZakupuRepository
    {

        private readonly ApplicationContext _context;
        public UgovorOZakupuRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UgovorOZakupuRepository()
        {

        }
        public bool CreateUgovorOZakupu(Models.UgovorOZakupu ugovorMap)
        {
            _context.Add(ugovorMap);
            return Save();
            throw new NotImplementedException();
        }

      

        public bool DeleteUgovorOZakupu(Models.UgovorOZakupu ugovor)
        {
            _context.Remove(ugovor);
            return Save();
            throw new NotImplementedException();
        }

        public ICollection<Models.UgovorOZakupu> GetUgovoriOZakupu()
        {
            return _context.Ugovori.OrderBy(p => p.UgovorID).Include(x => x.javnoNadmetanje).Include(x => x.licnost).Include(x => x.dokument).Include(x => x.kupac).ToList();
            throw new NotImplementedException();
        }

        public Models.UgovorOZakupu GetUgovorOZakupuByID(int id)
        {
            return _context.Ugovori.Where(p => p.UgovorID == id).Include(x => x.javnoNadmetanje).Include(x => x.licnost).Include(x => x.dokument).Include(x => x.kupac).FirstOrDefault();
        } 
            
    
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UgovorOZakupuExsists(int id)
        {
            return _context.Ugovori.Any(p => p.UgovorID == id);
            throw new NotImplementedException();
        }

        public bool UpdateUgovorOZakupu(Models.UgovorOZakupu ugovor)
        {
            _context.Update(ugovor);
            return Save();
            throw new NotImplementedException();
        }
    }
}
