using Microsoft.EntityFrameworkCore;
using PriceFlex_Backend.Models;

namespace PriceFlex_Backend.Data
{
    public class DbSeeder
    {
        private readonly ModelBuilder modelBuilder;

        public DbSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
          
            {
                modelBuilder.Entity<OnlineShopScrapper>().HasData(

                    new OnlineShopScrapper() {
                        Id = 55,
                        Name = "Media Expert",
                        Classes = ".main-price .whole",
                        Url = "https://www.mediaexpert.pl/komputery-i-tablety/laptopy-i-ultrabooki/laptopy/laptop-lenovo-ideapad-gaming-3-15ach6-15-6-ips-144hz-r5-5500h-16gb-ram-512gb-ssd-geforce-rtx2050-windows-11-home"

                    },

                      new OnlineShopScrapper()
                      {
                          Id = 8,
                          Name = "Vinted",
                          Classes = ".main-price .whole",
                          Url = "https://www.mediaexpert.pl/komputery-i-tablety/laptopy-i-ultrabooki/laptopy/laptop-lenovo-ideapad-gaming-3-15ach6-15-6-ips-144hz-r5-5500h-16gb-ram-512gb-ssd-geforce-rtx2050-windows-11-home"

                      }





           );

            }
           
        }
    }
}
