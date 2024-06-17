namespace PriceFlex_Backend.Models
{
    public class OnlineShopScrapper
    {
        public string Name { get; set; }
        public string Classes { get; set; }

        public string Url { get; set; }

        public List<ScrapperPrice> Prices { get; set; }
    }
}
