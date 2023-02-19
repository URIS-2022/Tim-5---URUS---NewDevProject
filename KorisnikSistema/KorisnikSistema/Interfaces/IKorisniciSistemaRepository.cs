using KorisnikSistema.Data1;
using KorisnikSistema.Models;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace KorisnikSistema.Interfaces
{
    public interface IKorisniciSistemaRepository : IBaseRepository<int, KorisniciSistema>
    {
        IEnumerable<KorisniciSistema> GetAll(string? includeProperties = null);
        public KorisniciSistema GetById(Expression<Func<KorisniciSistema, bool>> filter, string? includeProperties = null);

        public bool Delete(Expression<Func<KorisniciSistema, bool>> filter, string? includeProperties = null);
    }
}
