using Zalba_Mikroservis.Data;
using Zalba_Mikroservis.Interfaces;
using Zalba_Mikroservis.Models;

namespace Zalba_Mikroservis.Repository
{
    public class KupacVORepository : IKupacVORepository
    {
        private readonly DataContext _context;
        public KupacVORepository(DataContext context)
        {
            _context = context;
        }
        //POST
        public bool CreateKupacVO(KupacVO kupacVO)
        {
            _context.Add(kupacVO);
            _context.SaveChanges();
            return Save();
            throw new NotImplementedException();

        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();

        }

        //GETBYID
        public KupacVO GetKupacVOById(int id)
        {
            return _context.KupacVOs.Where(k => k.KupacID == id).FirstOrDefault();
            throw new NotImplementedException();

        }

        //GETALL
        public ICollection<KupacVO> GetKupacVOs()
        {
            return _context.KupacVOs.OrderBy(k => k.KupacID).ToList();
            throw new NotImplementedException();

        }

        public bool KupacVOExist(int KupId)
        {
            return _context.KupacVOs.Any(k => k.KupacID == KupId);
        }
        //PUT
        public bool UpdateKupacVO(KupacVO kupacVO)
        {
            _context.Update(kupacVO);
            return Save();
            throw new NotImplementedException();

        }
        //DELETE
        public bool DeleteKupacVO(KupacVO kupacVO)
        {
            _context.Remove(kupacVO);
            return Save();
        }

    }
}
