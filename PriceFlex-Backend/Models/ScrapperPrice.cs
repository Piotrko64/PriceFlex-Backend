using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class ScrapperPrice : BasicModel
    {
        [Required]
        public float Price { get; set; }
        public string OnlineShopScrapperId { get; set; }
    }
}
