using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Helpers;

namespace WebPreisBerechnungAuB.Services
{
    public class LoadAndModifyImage : ILoadAndModifyImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoadAndModifyImage(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public string InvertColor(string Image, string removeArray)
        {

            var ImageWithoutAnnotation = SubstringBase64Image(Image);


       
            // example

            Bitmap pic = Base64StringToBitmap(ImageWithoutAnnotation);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }


            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            // string uploads = Path.Combine(uploadsFolder, file.FileName);
            var separator = Path.DirectorySeparatorChar.ToString();
            pic.Save(uploadsFolder + separator + "BgRemoved" + ".png");


            //convert to base64 image
            System.IO.MemoryStream ms = new MemoryStream();
            pic.Save(ms, ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage);

            return SigBase64;
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

        public static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;
            //Convert Base64 string to byte[]
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }
    }
}
