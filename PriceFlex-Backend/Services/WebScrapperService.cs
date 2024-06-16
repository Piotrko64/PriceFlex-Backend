using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace PriceFlex_Backend.Services
{
    public class WebScrapperService
    {

       

        public string GetPriceByUrlAndClasses(string url, string classes)
        {

            
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var content = doc.QuerySelector(classes).InnerText;
            

            return content;

        }




    }
}
