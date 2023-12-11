namespace WebPreisBerechnungAuB.Models
{
    public class ArticleSize
    {
        public int Id { get; set; }

        public string FarbName { get; set; }

        public string HexColor { get; set; }

        public string Size { get; set; }

        public string Gewicht { get; set; }
        public int Lagerstand { get; set; }

        public ArticleSize(string size,string farbname, string hexColor, int lagerstand,int id,string gewicht)
        {
            Size = size;
            Lagerstand = lagerstand;
            Id = Id;
            FarbName = farbname;
            HexColor = hexColor;
            Gewicht = gewicht;

        }
    }
}
