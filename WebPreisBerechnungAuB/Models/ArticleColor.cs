namespace WebPreisBerechnungAuB.Models
{
    public class ArticleColor
    {

        public ArticleColor(string name,string hexcolor)
        {
            Name = name;
            HexColor = hexcolor;
        }

        public int Id { get; set; }

        public string Name { get; set; }   
        public string HexColor { get; set; }
    }
}