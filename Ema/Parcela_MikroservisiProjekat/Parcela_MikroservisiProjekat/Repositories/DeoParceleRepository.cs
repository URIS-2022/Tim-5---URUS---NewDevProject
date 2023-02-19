using Parcela_MikroservisiProjekat.Interface;
using Parcela_MikroservisiProjekat.Models;

namespace Parcela_MikroservisiProjekat.Repositories
{
    public class DeoParceleRepository : IDeoParceleRepository
    {
        private readonly ParcelaContext _context;
        public DeoParceleRepository(ParcelaContext context)
        {
            _context = context;
        }
        public DeoParceleRepository()
        {
        }

        public ICollection<DeoParcele> getAllDeoParcele()
        {
            return _context.deoParcele.OrderBy(p => p.deoParceleId).ToList();
            throw new NotImplementedException();
        }

        public DeoParcele getDeoParceleByID(int id)
        {
            return _context.deoParcele.Where(p => p.deoParceleId == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public bool postDeoParcele(DeoParcele deoParceleMap)
        {
            _context.Add(deoParceleMap);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool updateDeoParcele(DeoParcele deoParcele)
        {
            _context.Update(deoParcele);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool deleteDeoParcele(DeoParcele deoParcele)
        {
            _context.Remove(deoParcele);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool deoParceleExsists(int id)
        {
            return _context.deoParcele.Any(p => p.deoParceleId == id);
            throw new NotImplementedException();
        }
    }
}
