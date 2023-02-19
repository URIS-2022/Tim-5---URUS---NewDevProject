using JavnoNadPavle.Data;
using JavnoNadPavle.Interfaces;
using JavnoNadPavle.Models;
using System.Collections.ObjectModel;

namespace JavnoNadPavle.Repository
{
    public class EtapaRepository : IEtapaRepository
    {
        private readonly DataContext _context;

        public EtapaRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEtapa(Etapa etapa)
        {
            _context.Add(etapa);
            return Save();
        }

        public bool DeleteEtapa(Etapa etapa)
        {
            _context.Remove(etapa);
            return Save();
        }
        public ICollection<Etapa> GetEtape()
        {
            return _context.Etape.OrderBy(p => p.EtapaID).ToList();
        }
        public Etapa GetEtapa(int id)
        {
            return _context.Etape.Where(p => p.EtapaID == id).FirstOrDefault();
            throw new NotImplementedException();
        }
        public bool EtapaExists(int nadId)
        {
            return _context.Etape.Any(p => p.EtapaID != nadId);
        }

        

        

        public bool Save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateEtapa(Etapa etapa)
        {
            _context.Update(etapa);
            return Save();
        }

        
    }
}
