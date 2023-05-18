namespace WebPreisBerechnungAuB.Services
{
    public interface ILoadAndModifyImage
    {
        /// <summary> 
        /// Get the image and remove the Background 
        /// finaly send it back via Json
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="removeArray">the array with the rgb value to remove the color.</param>
        /// <returns>Json value</returns>
        public string RemoveBackground(string Image, string removeArray);
        public string InvertColor(string Image, string removeArray);

        public string SubstringBase64Image(string data);
    }
}
