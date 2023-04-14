using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Services
{
    public class LoadAndModifyImage : ILoadAndModifyImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoadAndModifyImage(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public string RemoveBackground(string Image)
        {
            var ImageWithoutAnnotation = SubstringBase64Image(Image);

            var _image = MagickImage.FromBase64(ImageWithoutAnnotation);

            _image.ColorFuzz = new Percentage(44);
            MagickColor RemoveColor = MagickColor.FromRgb((byte)0, (byte)255, (byte)0);
            _image.Opaque(RemoveColor, MagickColors.None);




            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            // string uploads = Path.Combine(uploadsFolder, file.FileName);
            var separator = Path.DirectorySeparatorChar.ToString();
            _image.Write(uploadsFolder + separator + "BgRemoved" + ".png");

            return _image.ToBase64();

        }

        public string SubstringBase64Image(string data)
        {
            string strStart = ",";
            string strEnd = "\"";
            int Start, End;

            Start = data.IndexOf(strStart, 20) + strStart.Length;
            End = data.IndexOf(strEnd, Start);
            End = data.Length;

            return data.Substring(Start, End - Start); ;
        }
    }
}
