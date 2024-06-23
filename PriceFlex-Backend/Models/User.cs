using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class User : BasicModel
    {

        [MaxLength(500)]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public int? AllowedScrappers { get; set; }


        virtual public List<OnlineShop> OnlineShops { get; set; }
        virtual public List<ScrapperConfig> ScrapperConfigs { get; set; }

        virtual public List<ScrapperData> ScrapperDatas { get; set; }

    }


    public enum UserRole
    {
        Admin,
        LimitedUser,
        CustomUser,
        StandardUser
    }
}
