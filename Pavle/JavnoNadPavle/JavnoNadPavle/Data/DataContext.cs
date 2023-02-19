using JavnoNadPavle.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JavnoNadPavle.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Nadmetanje> Nadmetanja { get; set; }
        public DbSet<JavnoNadmetanje> JavnaNadmetanja { get; set; }

        public DbSet<Etapa> Etape { get; set; }




    }
}
