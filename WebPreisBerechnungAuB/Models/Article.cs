using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Preis")]

        public double Price { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }


        public string Manufacturer { get; set; }

        //[DisplayName("Beschreibung")]

        public List<string> Descriptions = new List<string>();

        // [DisplayName("Artribute")]

        public List<AttributeArticle> Attributes = new List<AttributeArticle>();
        public File File { get; set; }

        public List<ArticleColor> ArticleColors = new List<ArticleColor>();
        public List<ArticleSize> ArticleSizes = new List<ArticleSize>();




    }
}
