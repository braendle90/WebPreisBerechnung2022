namespace WebPreisBerechnungAuB.Repo
{
    public class LogoSizeAndAspectRatio
    {

        public int Id { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal ratiowidth { get; set; }
        public decimal ratioheight { get; set; }

        public decimal aspectRatio { get; set; }

        public int IdLogo { get; set; }


        public void CalcRatio(decimal height, decimal width)
        {


            aspectRatio = width / height;

            //if (width > height)
            //{
            //    ratiowidth = width / height;
            //}
            //else
            //{
            //    ratioheight = height / width;

            //}
        }
    }
}
