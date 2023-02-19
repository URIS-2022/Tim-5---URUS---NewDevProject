using LicnostProjekat.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LicnostProjekat.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Adresa> Adresas { get; set; }
        public DbSet<FizickoLice> FizickaLicas { get; set; }
        public DbSet<KontaktOsoba> KontaktOsobas { get; set; }
        public DbSet<Kupac> Kupcis { get; set; }
        public DbSet<Licnost> Licnostis { get; set; }
        public DbSet<PravnoLice> PravnaLicas { get; set; }
    }
}
