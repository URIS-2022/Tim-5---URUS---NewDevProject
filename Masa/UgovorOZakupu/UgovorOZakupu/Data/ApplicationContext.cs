using UgovorOZakupu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace UgovorOZakupu.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<DokumentVO> Dokumenta  { get; set; }
        public DbSet<JavnoNadmetanjeVO> JavnaNadmetanja { get; set; }
        public DbSet<KupacVO> Kupci { get; set; }

        public DbSet<LicnostVO> Licnosti { get; set; }
        public DbSet<Models.UgovorOZakupu> Ugovori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DokumentVO>().HasData(
               new DokumentVO()
               {
                   DokumentID = 7,
                   ZavodniBroj = "123aA",
                   Datum = DateTime.Parse("2022-11-27"),
                   DatumDonosenjaDokumenta = DateTime.Parse("2009-11-27"),
                   Sablon = "neki sablonnnnnn"

               },
               new DokumentVO()
               {
                   DokumentID = 5,
                   ZavodniBroj = "123Aa",
                   Datum = DateTime.Parse("2009-11-27"),
                   DatumDonosenjaDokumenta = DateTime.Parse("2011-11-27"),
                   Sablon = "neki sablonnnnn"
               }
               );
            modelBuilder.Entity<JavnoNadmetanjeVO>().HasData(
               new JavnoNadmetanjeVO()
               {
                   JavnoNadmetanjeID= 6,
                   VremeKraja = "13.35h",
                   Tip = "neki tip",
                   Izuzeto = false,
                   IzlicitiranaCena = 150000,
                   BrojUcesnika = 26,
                   VisinaDopuneDepozita = 1350,
                   Status = "neki status"

               },
               new JavnoNadmetanjeVO()
               {
                   JavnoNadmetanjeID = 66,
                   VremeKraja = "13.35h",
                   Tip = "neki tip",
                   Izuzeto = false,
                   IzlicitiranaCena = 150000,
                   BrojUcesnika = 26,
                   VisinaDopuneDepozita = 1350,
                   Status = "neki status"

               }
               );
            modelBuilder.Entity<KupacVO>().HasData(
               new KupacVO()
               {
                   KupacID= 6,
                   Prioritet= "nema",
                   Lice = "nije ovlasceno",
                   OstvarenaPovrsina = 1505005,
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2021-06-06"),
                   DuzinaTrajanjaZabraneUGodinama = 2,
                   DatumPrestankaZabrane = DateTime.Parse("2023-06-06")
               },
               new KupacVO()
               {
                   KupacID = 666,
                   Prioritet = "nema",
                   Lice = "nije ovlasceno",
                   OstvarenaPovrsina = 1505005,
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2014-06-06"),
                   DuzinaTrajanjaZabraneUGodinama = 12,
                   DatumPrestankaZabrane = DateTime.Parse("2026-06-06")
               }
               );
            modelBuilder.Entity<LicnostVO>().HasData(
               new LicnostVO()
               {
                   LicnostID= 6,
                   Ime = "Masa",
                   Prezime = "Bobar",
                   Funkcija = "ucesnik"
               },
               new LicnostVO()
               {
                   LicnostID = 65,
                   Ime = "Ema",
                   Prezime = "Kuzmanovic",
                   Funkcija = "ucesnik"
               }
               );
            modelBuilder.Entity<Models.UgovorOZakupu>().HasData(
               new Models.UgovorOZakupu()
               {
                   UgovorID = 1,
                   Odluka = "nije donesena nikakva konacna odluka",
                   TipGarancije = "godisnja",
                   Lice = "neko lice",
                   RokoviDospeca = 2,
                   ZavodniBroj = "123a",
                   DatumZavodjenja = DateTime.Parse("2022-12-01"),
                   Ministar = "ekonomije",
                   RokZaVracanjeZemljista = DateTime.Parse("2026-12-01"),
                   MestoPotpisivanja = "Beograd",
                   DatumPotpisa = DateTime.Parse("2022-12-01"),
                   javnoNadmetanjeID = 6,
                   dokumentID = 7,
                   licnostID = 65,
                   kupacID = 666
               },
               new Models.UgovorOZakupu()
               {
                   UgovorID = 2,
                   Odluka = "nije donesena nikakva konacna odluka",
                   TipGarancije = "godisnja",
                   Lice = "neko lice",
                   RokoviDospeca = 2,
                   ZavodniBroj = "123a",
                   DatumZavodjenja = DateTime.Parse("2022-12-01"),
                   Ministar = "ekonomije",
                   RokZaVracanjeZemljista = DateTime.Parse("2026-12-01"),
                   MestoPotpisivanja = "Beograd",
                   DatumPotpisa = DateTime.Parse("2022-12-01"),
                  javnoNadmetanjeID = 6,
                  dokumentID = 7,
                  licnostID = 65,
                  kupacID = 666
               }
               );



        }

        }
}
