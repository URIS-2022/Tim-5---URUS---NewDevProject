using Microsoft.EntityFrameworkCore;
using Zalba_Mikroservis.Models;

namespace Zalba_Mikroservis.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<KupacVO> KupacVOs { get; set; }
        public DbSet<Zalba> Zalbas { get; set; }
    }
}
