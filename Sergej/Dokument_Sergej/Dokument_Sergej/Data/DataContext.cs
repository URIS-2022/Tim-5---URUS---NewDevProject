using Dokument_Sergej.Models;
using Microsoft.EntityFrameworkCore;

namespace Dokument_Sergej.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }  
        
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<KorisnikSistema> KorisniciSistema { get; set; }    
        public DbSet<Licnost> Licnosti { get; set; }    
    }
}
