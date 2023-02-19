using Microsoft.EntityFrameworkCore;
using Parcela_MikroservisiProjekat.Interface;
using Parcela_MikroservisiProjekat.Models;

namespace Parcela_MikroservisiProjekat.Repositories
{
    public class ParcelaRepository : IParcelaRepository
    {
        private readonly ParcelaContext _context;
        public ParcelaRepository(ParcelaContext context)
        {
            _context = context;
        }
        public ParcelaRepository()
        {
        }


        public bool deleteParcela(Parcela parcela)
        {
            _context.Remove(parcela);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public ICollection<Parcela> getAllParcela()
        {
            return _context.parcela.OrderBy(p => p.parcelaId).Include(x => x.deoParcele).Include(x => x.katastarskaOpstina).ToList();
            throw new NotImplementedException();
        }

        public Parcela getParcelaByID(int id)
        {
            return _context.parcela.Where(p => p.parcelaId == id).Include(x => x.deoParcele).Include(x => x.katastarskaOpstina).FirstOrDefault();
        }

        public bool parcelaExsists(int id)
        {
            return _context.parcela.Any(p => p.parcelaId == id);
            throw new NotImplementedException();
        }

        public bool postParcela(Parcela parcelaMap)
        {
            _context.Add(parcelaMap);
            return SaveChanges();
            throw new NotImplementedException();
        }

        /*public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }*/

        public bool updateParcela(Parcela parcela)
        {
            _context.Update(parcela);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }
    }
}
