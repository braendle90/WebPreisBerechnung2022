using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;

namespace WebPreisBerechnungAuB.Services
{
    public class LoadAndModifyImage : ILoadAndModifyImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoadAndModifyImage(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public string RemoveBackground(string Image, string removeArray)
        {



            var ImageWithoutAnnotation = SubstringBase64Image(Image);
            string[] modifedArray = removeArray.Split(',').Select(str => str.Trim()).ToArray();


            byte[] removeArraySplited = new byte[modifedArray.Length];

            //removeArraySplited[i] = modifedArray[i].Select(s => Convert.ToByte(s)).ToArray();
            byte[] _Byte = modifedArray.Select(s => Byte.Parse(s)).ToArray();



            var _image = MagickImage.FromBase64(ImageWithoutAnnotation);

            _image.ColorFuzz = new Percentage(11);
            MagickColor RemoveColor = MagickColor.FromRgba(_Byte[0], _Byte[1], _Byte[2], _Byte[3]);
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
