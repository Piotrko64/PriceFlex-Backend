using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class ScrapperConfig : BasicModel
    {


        [Required]
        public string Name { get; set; }

        [Required]
        public string Classes { get; set; }

        public string Url { get; set; }

        public int OnlineShopId { get; set; }

        public int UserId { get; set; }



        public virtual List<ScrapperData> ScrapperDatas { get; set; }
    }
}
