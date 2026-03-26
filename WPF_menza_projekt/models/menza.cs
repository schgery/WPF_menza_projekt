using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_menza_projekt.models
{
    public class menza : DbContext
    {
        public DbSet<desszert> desszertek { get; set; }
        public DbSet<leves> levesek { get; set; }
        public DbSet<napietkezes> napietkezesek { get; set; }
        public DbSet<foetel> foetelek { get; set; }
        public DbSet<vendeg> vendegek { get; set; }
        public DbSet<vendegnapietkezes> vendegnapietkezesek { get; set; }

        string c = "Server=localhost;Database=menza;Uid=root;Pwd=;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(c, ServerVersion.AutoDetect(c));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vendegnapietkezes>()
                .HasKey(x => new { x.vendegid, x.napietkezesid });
        }
    }
}
