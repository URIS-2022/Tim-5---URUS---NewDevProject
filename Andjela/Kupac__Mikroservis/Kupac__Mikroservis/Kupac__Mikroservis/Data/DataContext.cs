using Kupac__Mikroservis.Models;
using Microsoft.EntityFrameworkCore;

namespace Kupac__Mikroservis.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<AdresaVO> AdresaVOs { get; set; }
        public DbSet<Kupac> Kupacs { get; set; }
        public DbSet<OvlascenoLice> OvlasceniLices { get; set; }
        public DbSet<Uplata> Uplatas { get; set; }

    }
}
