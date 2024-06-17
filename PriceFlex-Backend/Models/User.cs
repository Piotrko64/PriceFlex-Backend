using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class User : BasicModel
    {


        public string Email { get; set; }

        //public UserRole Role { get; set; }

       
        //public List<OnlineShopScrapper> OnlineShopScrappers { get; set; }
        //public List<ScrapperPrice> ScrapperPrice { get; set; }

    }


    public enum UserRole
    {
        Admin,
        LimitedUser,
        CustomUser,
        StandardUser
    }
}
