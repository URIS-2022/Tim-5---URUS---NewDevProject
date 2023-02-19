using AutoMapper;
using KorisnikSistema.Data1;
using KorisnikSistema.Interfaces;
using KorisnikSistema.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace KorisnikSistema.Repository
{
    public class KorisniciSistemaRepository : BaseRepository<int, KorisniciSistema>, IKorisniciSistemaRepository
    {
        private readonly DataContext _context;
        public KorisniciSistemaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<KorisniciSistema> GetAll(string? includeProperties = null)
        {
            IQueryable<KorisniciSistema> query = _context.Set<KorisniciSistema>();

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public KorisniciSistema GetById(Expression<Func<KorisniciSistema, bool>> filter, string? includeProperties = null)
        {
            IQueryable<KorisniciSistema> query = _context.Set<KorisniciSistema>();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public bool Delete(Expression<Func<KorisniciSistema, bool>> filter, string? includeProperties = null)
        {
            IQueryable<KorisniciSistema> query = _context.Set<KorisniciSistema>();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (query == null) return false;


            _context.Set<KorisniciSistema>().Remove(query.FirstOrDefault());


            _context.SaveChanges();

            return true;
        }


    }
}
