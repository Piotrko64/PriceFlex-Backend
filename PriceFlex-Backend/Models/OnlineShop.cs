using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class OnlineShop : BasicModel
    {
        [Required]
        public string Name { get; set; }

        public string LogoImageUrl { get; set; }
        
        public string BasicUrl { get; set; }

        virtual public List<ScrapperConfig> ScrapperConfigs { get; set; }
        virtual public List<ScrapperData> ScrapperDatas { get; set; }
    }
}
