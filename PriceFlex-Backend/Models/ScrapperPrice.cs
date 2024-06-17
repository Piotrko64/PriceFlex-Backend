namespace PriceFlex_Backend.Models
{
    public class ScrapperPrice : BasicModel
    {
        public float Price { get; set; }
        public string OnlineShopScrapperId { get; set; }
    }
}
