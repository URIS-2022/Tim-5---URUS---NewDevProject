using LicnostProjekat.Data;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;
using Microsoft.EntityFrameworkCore;

namespace LicnostProjekat.Repository
{
    public class FizickoLiceRepository : IFizickoLiceRepository
    {
        private readonly DataContext _context;
        public FizickoLiceRepository(DataContext context)
        {
            _context = context;
        }

        public bool createFizickoLice(FizickoLice item)
        {
                _context.Add(item);
            return Save();
        }

        public bool deleteFizickoLice(FizickoLice fizickoLice)
        {
            _context.Remove(fizickoLice);
            return Save();
        }

        public FizickoLice GetFizickoLice(int id)//GET BY iD
        {
            return _context.FizickaLicas.Where(p => p.FizickoLiceID == id).Include(x => x.adresa).Include(x => x.KontaktOsoba).Include(x => x.Licnost).FirstOrDefault();
        }

        public ICollection<FizickoLice> GetFizickoLices()//GET ALL
        {
            return _context.FizickaLicas.OrderBy(p => p.FizickoLiceID).Include(x => x.adresa).Include(x => x.KontaktOsoba).Include(x => x.Licnost).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0 ? true: false;
        }

        public bool updateFizickoLice(FizickoLice fizickoLice)
        {
            _context.Update(fizickoLice);
            return Save();
        }
    }
}
