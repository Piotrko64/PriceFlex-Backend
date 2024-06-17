using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class ScrapperPrice : BasicModel
    {
        [Required]
        public  double Price { get; set; }

        [Required]
        public  int OnlineShopScrapperId { get; set; }

 
        public string Url { get; set; }
    }
}
