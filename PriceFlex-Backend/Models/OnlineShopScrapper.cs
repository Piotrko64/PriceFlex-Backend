using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class OnlineShopScrapper : BasicModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Classes { get; set; }

        [Required]
        public string Url { get; set; }

        virtual public List<ScrapperPrice> Prices { get; set; }
    }
}
