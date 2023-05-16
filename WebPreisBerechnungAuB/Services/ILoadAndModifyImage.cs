namespace WebPreisBerechnungAuB.Services
{
    public interface ILoadAndModifyImage
    {
        public string RemoveBackground(string Image, string removeArray);
        public string InvertColor(string Image, string removeArray);

        public string SubstringBase64Image(string data);
    }
}
