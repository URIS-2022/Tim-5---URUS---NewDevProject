using KatastarskaOpstina_MikroservisiProjekat.Interface;
using KatastarskaOpstina_MikroservisiProjekat.Models;

namespace KatastarskaOpstina_MikroservisiProjekat.Repositories
{
    public class KatastarskaOpstinaRepository : IKatastarskaOpstinaRepository
    {
        private readonly KatastarskaOpstinaContext _context;
        public KatastarskaOpstinaRepository(KatastarskaOpstinaContext context)
        {
            _context = context;
        }
        public KatastarskaOpstinaRepository()
        {
        }



        public bool deleteKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            _context.Remove(katastarskaOpstina);
            return SaveChanges();
            throw new NotImplementedException();
        }

        

        public KatastarskaOpstina getKatastarskaOpstinaByID(int id)
        {
            return _context.katastarskaOpstina.Where(p => p.katastarskaOpstinaId == id).FirstOrDefault();
        }

        public bool katastarskaOpstinaExsists(int id)
        {
            return _context.katastarskaOpstina.Any(p => p.katastarskaOpstinaId == id);
        }

        public bool postKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            _context.Add(katastarskaOpstina);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool updateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            _context.Update(katastarskaOpstina);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public ICollection<KatastarskaOpstina> getAllKatastarskaOpstina()
        {
            return _context.katastarskaOpstina.OrderBy(p => p.katastarskaOpstinaId).ToList();
            throw new NotImplementedException();
        }
    }
}
