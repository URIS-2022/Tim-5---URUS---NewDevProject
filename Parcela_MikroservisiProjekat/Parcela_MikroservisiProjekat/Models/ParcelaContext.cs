using Microsoft.EntityFrameworkCore;

namespace Parcela_MikroservisiProjekat.Models
{
    public class ParcelaContext : DbContext
    {
        public ParcelaContext(DbContextOptions<ParcelaContext> options)
                : base(options)
        {

        }


        public DbSet<Parcela> parcela { get; set; }
        public DbSet<DeoParcele> deoParcele { get; set; }
        public DbSet<KatastarskaOpstinaVO> katastarskaOpstinaVO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcela>().HasData(
                new Parcela()
                {
                    parcelaId = 1,
                    povrsina = "300m2",
                    korisnikParcele = "Masa Bobar",
                    brojParcele = 1,
                    brojListaNepokretnosti = 1,
                    kultura = "kultura1",
                    klasa = "vrhunska",
                    obradivost = "visoka",
                    zasticenaZona = "ima",
                    oblikSvojine = "Nasledstvo",
                    odvodnjavanje = "da",
                    kulturaStvarsnoStanje = "visoka",
                    klasaStvarnoStanje = "visoka",
                    obradivostStvarnoStanje = "niska",
                    zasticenaZonaStvarnoStanje = "visoka",
                    odvodnjavanjeStvarnoStanje = "povoljno",
                    deoParceleId=1,
                    katastarskaOpstinaId=1

                },
                new Parcela()
                {
                    parcelaId = 2,
                    povrsina = "400m2",
                    korisnikParcele = "Uros Bobar",
                    brojParcele = 2,
                    brojListaNepokretnosti = 2,
                    kultura="kultura1",
                    klasa="vrhunska",
                    obradivost="visoka",
                    zasticenaZona="ima",
                    oblikSvojine = "Nasledstvo",
                    odvodnjavanje="da",
                    kulturaStvarsnoStanje = "visoka",
                    klasaStvarnoStanje = "visoka",
                    obradivostStvarnoStanje = "niska",
                    zasticenaZonaStvarnoStanje = "visoka",
                    odvodnjavanjeStvarnoStanje = "povoljno",
                    deoParceleId=2,
                    katastarskaOpstinaId=2
                },
                new Parcela()
                {
                    parcelaId = 3,
                    povrsina = "500m2",
                    korisnikParcele = "Aleksa Bobar",
                    brojParcele = 3,
                    brojListaNepokretnosti = 3,
                    kultura = "kultura1",
                    klasa = "vrhunska",
                    obradivost = "visoka",
                    zasticenaZona = "ima",
                    oblikSvojine = "Nasledstvo",
                    odvodnjavanje = "da",
                    kulturaStvarsnoStanje = "visoka",
                    klasaStvarnoStanje = "visoka",
                    obradivostStvarnoStanje = "niska",
                    zasticenaZonaStvarnoStanje = "visoka",
                    odvodnjavanjeStvarnoStanje = "povoljno",
                    deoParceleId=3,
                    katastarskaOpstinaId = 3
                }
                );
            modelBuilder.Entity<KatastarskaOpstinaVO>().HasData(
                    new KatastarskaOpstinaVO()
                    {
                        katastarskaOpstinaId = 1,
                        katastarskaOpstinaNaziv = "Lipovac"
                    },
                    new KatastarskaOpstinaVO()
                    {
                        katastarskaOpstinaId = 2,
                        katastarskaOpstinaNaziv = "Brus"
                    },
                    new KatastarskaOpstinaVO()
                    {
                        katastarskaOpstinaId = 3,
                        katastarskaOpstinaNaziv = "Odzaci"
                    }
                    );
            modelBuilder.Entity<DeoParcele>().HasData(
                    new DeoParcele()
                    {
                        deoParceleId=1,
                        povrsina="200m2",
                        redniBroj=3
    },
                    new DeoParcele()
                    {
                        deoParceleId = 2,
                        povrsina = "300m2",
                        redniBroj = 4
                    },
                    new DeoParcele()
                    {
                        deoParceleId = 3,
                        povrsina = "400m2",
                        redniBroj = 5
                    }
                    );

        }
    }
}
