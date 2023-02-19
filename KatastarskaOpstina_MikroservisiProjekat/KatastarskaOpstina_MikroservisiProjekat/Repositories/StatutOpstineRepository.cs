using KatastarskaOpstina_MikroservisiProjekat.Interface;
using KatastarskaOpstina_MikroservisiProjekat.Models;
using Microsoft.EntityFrameworkCore;

namespace KatastarskaOpstina_MikroservisiProjekat.Repositories
{
    public class StatutOpstineRepository : IStatutOpstineRepository
    {
        private readonly KatastarskaOpstinaContext _context;
        public StatutOpstineRepository(KatastarskaOpstinaContext context)
        {
            _context = context;
        }
        public StatutOpstineRepository()
        {
        }





        public bool deleteStatutOpstine(StatutOpstine statutOpstine)
        {
            _context.Remove(statutOpstine);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public ICollection<StatutOpstine> getAllStatutOpstine()
        {
            return _context.statutOpstine.OrderBy(p => p.statutOpstineID).Include(x => x.katastarskaOpstina).ToList();
            throw new NotImplementedException();
        }

        public StatutOpstine getStatutOpstineByID(int id)
        {
            return _context.statutOpstine.Where(p => p.statutOpstineID == id).Include(x => x.katastarskaOpstina).FirstOrDefault();
            throw new NotImplementedException();
        }

        public bool postStatutOpstine(StatutOpstine statutOpstine)
        {
            _context.Add(statutOpstine);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool statutOpstineExsists(int id)
        {
            return _context.statutOpstine.Any(p => p.statutOpstineID == id);
            throw new NotImplementedException();
        }

        public bool updateStatutOpstine(StatutOpstine statutOpstine)
        {
            _context.Update(statutOpstine);
            return SaveChanges();
            throw new NotImplementedException();
        }

    }
}
