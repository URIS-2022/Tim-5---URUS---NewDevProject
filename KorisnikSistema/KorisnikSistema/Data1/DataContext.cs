using KorisnikSistema.Models;
using Microsoft.EntityFrameworkCore;

namespace KorisnikSistema.Data1
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<KorisniciSistema> KorisniciSistemas { get; set; }
        public DbSet<TipKorisnika> TipKorisnikas { get; set; }
    }
}
