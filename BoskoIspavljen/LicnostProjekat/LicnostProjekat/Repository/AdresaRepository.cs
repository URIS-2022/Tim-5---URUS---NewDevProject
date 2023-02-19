using LicnostProjekat.Data;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;

namespace LicnostProjekat.Repository
{
    public class AdresaRepository : IAdresaRepository
    {
        private readonly DataContext _context;
        public AdresaRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateAdresa(Adresa adresa)
        {
            //change tracker
            _context.Add(adresa);
            return Save();
        }

        public bool DeleteAdresa(Adresa adresa)
        {
            _context.Remove(adresa);
            return Save();
        }

        public Adresa getAdresaByID(int id)// GET BY ID
        {
            return _context.Adresas.Where(p => p.AdresaID == id).FirstOrDefault();
        }


        public ICollection<Adresa> GetAdresas()// GET ALL 
        {
            return _context.Adresas.OrderBy(p => p.AdresaID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0? true: false;
        }

        public bool UpdateAdresa(Adresa adresa)
        {
            _context.Update(adresa);
            return Save();
        }
    }
}
