using Microsoft.EntityFrameworkCore;

namespace KatastarskaOpstina_MikroservisiProjekat.Models
{
    
        public class KatastarskaOpstinaContext : DbContext
        {
            public KatastarskaOpstinaContext(DbContextOptions<KatastarskaOpstinaContext> options)
                : base(options)
            {

            }



            public DbSet<KatastarskaOpstina> katastarskaOpstina { get; set; }
            public DbSet<StatutOpstine> statutOpstine { get; set; }



            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<KatastarskaOpstina>().HasData(
                    new KatastarskaOpstina()
                    {
                        katastarskaOpstinaId = 1,
                        katastarskaOpstinaNaziv = "Lipovac"
                    },
                    new KatastarskaOpstina()
                    {
                        katastarskaOpstinaId = 2,
                        katastarskaOpstinaNaziv = "Brus"
                    },
                    new KatastarskaOpstina()
                    {
                        katastarskaOpstinaId = 3,
                        katastarskaOpstinaNaziv = "Odzaci"
                    }
                    );
                modelBuilder.Entity<StatutOpstine>().HasData(
                    new StatutOpstine()
                    {
                        statutOpstineID = 4,
                        clan = "prvi",
                        stav = "11",
                        tacka = "1",
                        katastarskaOpstinaID = 1
                    },
                    new StatutOpstine()
                    {
                        statutOpstineID = 5,
                        clan = "drugi",
                        stav = "12",
                        tacka = "2",
                        katastarskaOpstinaID = 2
                    },
                    new StatutOpstine()
                    {
                        statutOpstineID = 6,
                        clan = "treci",
                        stav = "13",
                        tacka = "3",
                        katastarskaOpstinaID = 3
                    });
            }


        }
    }

