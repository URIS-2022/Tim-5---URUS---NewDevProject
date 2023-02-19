using System.Diagnostics.Metrics;
using ZasticenaZonaMikroservis.DataContext;
using ZasticenaZonaMikroservis.Interface;
using ZasticenaZonaMikroservis.Models;

namespace ZasticenaZonaMikroservis.Repository
{
    public class ZasticenaZonaRepository : IZasticenaZonaRepository
    {
        private readonly ApplicationContext _context;
        public ZasticenaZonaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ZasticenaZonaRepository()
        {
        }
        /*
        public ICollection<ZasticenaZona> GetZasticeneZonas()
        {
            return _context.ZasticeneZone.OrderBy(p => p.ZasticenaZonaID).ToList();
            //toList je veoma bitno jer eksplicitno moramo navesti sta vracamo
        } */
        public ZasticenaZona GetZasticenaZona(int ID)
        {
            return _context.ZasticeneZone.Where(p => p.ZasticenaZonaID == ID).FirstOrDefault();
        }

        public ICollection<ZasticenaZona> GetZasticeneZone()
        {
            return _context.ZasticeneZone.OrderBy(p => p.ZasticenaZonaID).ToList();
            throw new NotImplementedException();
        }
            
        public bool ZasticenaZonaExsists(int id)
        {
           return _context.ZasticeneZone.Any(p => p.ZasticenaZonaID == id);
        }

        public bool CreateZasticenaZona(ZasticenaZona zasticenaZona)
        {
            _context.Add(zasticenaZona);
            return Save();
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }



        public bool UpdateZasticenaZona(ZasticenaZona zasticenaZona)
        {
            _context.Update(zasticenaZona);
            return Save();
            throw new NotImplementedException();
        }

        public bool DeleteZasticenaZona(ZasticenaZona zasticenaZona)
        {
            _context.Remove(zasticenaZona);
            return Save();
            throw new NotImplementedException();
        }

       
    }
}
