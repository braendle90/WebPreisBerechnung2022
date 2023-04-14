namespace WebPreisBerechnungAuB.Services
{
    public interface ILoadAndModifyImage
    {
        public string RemoveBackground(string Image);

        public string SubstringBase64Image(string data);
    }
}
