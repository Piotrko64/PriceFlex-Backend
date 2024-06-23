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
              /*  modelBuilder.Entity<OnlineShop>().HasData(

                    new OnlineShop() {
                        Id = 55,
                        Name = "Media Expert",
           
                    },

                      new OnlineShop()
                      {
                          Id = 8,
                          Name = "Vinted",
                         

                      }





           ); */

            }
           
        }
    }
}
