using Komisija_Sergej.Models;
using Microsoft.EntityFrameworkCore;

namespace Komisija_Sergej.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Komisija> Komisije { get; set; }
        
    }
}
