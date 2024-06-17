using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class User : BasicModel
    {

        [MaxLength(500)]
        public string Email { get; set; }

        public UserRole Role { get; set; }

       
       virtual public List<OnlineShopScrapper> OnlineShopScrappers { get; set; }
       virtual public List<ScrapperPrice> ScrapperPrices { get; set; }

    }


    public enum UserRole
    {
        Admin,
        LimitedUser,
        CustomUser,
        StandardUser
    }
}
