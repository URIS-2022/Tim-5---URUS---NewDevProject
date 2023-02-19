using Microsoft.EntityFrameworkCore;
using ZasticenaZonaMikroservis.Models;

namespace ZasticenaZonaMikroservis.DataContext
{
    
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<ZasticenaZona> ZasticeneZone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZasticenaZona>().HasData(
                new ZasticenaZona()
                {
                    ZasticenaZonaID = 5,
                    DozvoljeniRadovi = "uredjivanje staza",
                    StepenZastite = 5,
                    VrstaZasticenogPodrucja = "Nacionalni park"
                },
                new ZasticenaZona(){
                ZasticenaZonaID = 13,
                           DozvoljeniRadovi = "kopanje",
                           StepenZastite = 3,
                           VrstaZasticenogPodrucja = "rezervat"
                },
              new ZasticenaZona()
              {
               ZasticenaZonaID = 15,
               DozvoljeniRadovi = "kopanje, asfaltiranje",
               StepenZastite = 4,
               VrstaZasticenogPodrucja = "arheolosko naselje"
               }
              );
        }
    }
}
