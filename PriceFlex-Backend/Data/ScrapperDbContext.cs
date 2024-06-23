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
        public DbSet<OnlineShop> OnlineShopScrappers { get; set; }
        public DbSet<ScrapperData> ScrapperDatas { get; set; }
        public DbSet<ScrapperConfig> ScrapperConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            new DbSeeder(modelBuilder).Seed();


            modelBuilder
       .Entity<User>()
       .Property(e => e.Role)
       .HasConversion<string>();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = "server=localhost;user=root;database=priceflex";
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

    }
}
