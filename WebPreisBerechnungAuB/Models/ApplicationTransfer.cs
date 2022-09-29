namespace WebPreisBerechnungAuB.Models
{
    public class ApplicationTransfer
    {
        public int Id { get; set; }
        public double ApplicationPrice { get; set; }

        public string ApplicationName { get; set; }

        public int PiecesFrom { get; set; }
        public int PiecesTo { get; set; }

        public int From { get; set; }
        public int To { get; set; }
    }
}
