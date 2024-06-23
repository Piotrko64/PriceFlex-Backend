using System.ComponentModel.DataAnnotations;

namespace PriceFlex_Backend.Models
{
    public class ScrapperData : BasicModel
    {


        [Required]
        public double Price { get; set; }


        [Required]
        public DateTime Data { get; set; }





        public int ScrapperConfigId { get; set; }
        public virtual ScrapperConfig ScrapperConfig { get; set; }

    }
}
