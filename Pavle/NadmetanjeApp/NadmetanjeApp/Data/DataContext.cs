using Microsoft.EntityFrameworkCore;
using NadmetanjeApp.Models;

namespace NadmetanjeApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Nadmetanje> Nadmetanja { get; set; }
        public DbSet<OtvaranjePonude> OtvaranjePonuda { get; set; }






    }
}
