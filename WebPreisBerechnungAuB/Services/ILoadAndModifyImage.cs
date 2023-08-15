using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Services
{
    public interface ILoadAndModifyImage
    {
        /// <summary> 
        /// Get the image and remove the Background 
        /// save it and finaly send it back via ImageBase64
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="removeArray">the array with the rgb value to remove the color.</param>
        /// <returns>string ImageBase64</returns>
        public string RemoveBackground(ImageBackground imageBackground, string removeArray);
        public string ChangeColor(ImageBackground imageBackground, string removeArray);

        /// <summary>
        /// Invert the given Image such as from black to White
        /// and save it.
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="removeArray"></param>
        /// <returns>string ImageBase64</returns>
        public string InvertColor(string Image, string removeArray);
        /// <summary>
        /// Create the base64 image from the webpage string and remove the first letters
        /// so a Base64 image can be created.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Bitmap Base64Image</returns>
        public string SubstringBase64Image(string data);
        public string SubString(string data);
    }
}
