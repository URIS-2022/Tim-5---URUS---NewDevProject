using Licitacija_Project.Data;
using Licitacija_Project.Interface;
using Licitacija_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Licitacija_Project.Repository
{
    public class LicitacijaRepository : ILicitacijaRepository
    {
            private readonly DataContext _context;
            public LicitacijaRepository(DataContext context)
            {
                _context = context;
            }
            public bool CreateLicitacija(Licitacija licitacija)
            {
                _context.Add(licitacija);
                return Save();
            }

            public bool DeleteLicitacija(Licitacija licitacija)
            {
                _context.Remove(licitacija);
                return Save();
            }

            public Licitacija GetLicitacijaById(int id)
            {
                return _context.Licitacijas.Where(k => k.LicitacijaID == id).Include(x => x.javnoNadmetanjeVO).Include(x => x.dokumentVO).FirstOrDefault();
            }

            public ICollection<Licitacija> GetLicitacijas()
            {
                return _context.Licitacijas.OrderBy(k => k.LicitacijaID).Include(x => x.javnoNadmetanjeVO).Include(x => x.dokumentVO).ToList();
            }

            public bool LicitacijaExist(int LicitacijaId)
            {
                return _context.Licitacijas.Any(k => k.LicitacijaID == LicitacijaId);
            }

            public bool Save()
            {
                var saved = _context.SaveChanges();
                return saved > 0 ? true : false;
            }

            public bool UpdateLicitacija(Licitacija licitacija)
            {
                _context.Update(licitacija);
                return Save();
            }

        }
    }
