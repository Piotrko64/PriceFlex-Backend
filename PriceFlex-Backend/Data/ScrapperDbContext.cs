using Microsoft.EntityFrameworkCore;
using PriceFlex_Backend.Data.Configurations;
using PriceFlex_Backend.Models;

namespace PriceFlex_Backend.Data
{
    public class ScrapperDbContext : DbContext
    {
        public ScrapperDbContext(DbContextOptions<ScrapperDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .Property(r => r.Email)
               .IsRequired()
               .HasMaxLength(50);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = "server=localhost;user=root;database=priceflex";
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

    }
}
