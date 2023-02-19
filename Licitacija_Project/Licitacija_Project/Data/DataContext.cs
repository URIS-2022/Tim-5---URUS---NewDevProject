using Licitacija_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Licitacija_Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Licitacija> Licitacijas { get; set; }
        public DbSet<DokumentVO> DokumentVOs { get; set; }
        public DbSet<JavnoNadmetanjeVO> JavnoNadmetanjeVOs { get; set; }
    }
}
