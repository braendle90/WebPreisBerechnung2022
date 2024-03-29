﻿using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repo;
using WebPreisBerechnungAuB.Services;

namespace WebPreisBerechnungAuB.Controllers
{
    public class DesignerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ILoadAndModifyImage _LoadAndModifyImage { get; }

        public DesignerController(ApplicationDbContext context, ILoadAndModifyImage LoadAndModifyImage, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._LoadAndModifyImage = LoadAndModifyImage;
            this._webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {


            return View();
        }

        public IActionResult LoadImage()
        {



            return View("_EditPartialDesigner");


        }


        [HttpPost]
        public IActionResult ChangePickedColor(ImageBackground imageBackground)
        {


            var arraySubString = _LoadAndModifyImage.SubString(imageBackground.RemoveColorRGB);
            var arraySubStringChangeColorRGB = _LoadAndModifyImage.SubString(imageBackground.ChangeColorRGB);


            imageBackground.RemoveColorRGB = arraySubString;
            imageBackground.ChangeColorRGB = arraySubStringChangeColorRGB;

            var ImageBasej64 = _LoadAndModifyImage.ChangeColor(imageBackground, arraySubString);


            return Json(new { isValid = true, fileName = imageBackground.Name, imgBase64 = ImageBasej64 });

        }

        [HttpPost]
        public IActionResult orginImage(ImageBackground imageBackground)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            string uploads = Path.Combine(uploadsFolder, imageBackground.FileData.FileName);
            var separator = Path.DirectorySeparatorChar.ToString();
            var pathtoFileToSend = (uploadsFolder + separator + imageBackground.Name);

            byte[] imageArray = System.IO.File.ReadAllBytes(pathtoFileToSend);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return Json(new { isValid = true, fileName = imageBackground.Name, imgBase64 = base64ImageRepresentation }); ;
        }

        [HttpPost]
        public IActionResult InvertColor(ImageBackground imageBackground)
        {

            var BackgroundRemoveArray = imageBackground.RemoveColorRGB;
            var lengthString = BackgroundRemoveArray.Length;
            var arraySubString = BackgroundRemoveArray.Substring(1, lengthString - 2);
            imageBackground.RemoveColorRGB = arraySubString;

            var ImageBasej64 = _LoadAndModifyImage.InvertColor(imageBackground.ImageBase64, arraySubString);


            return Json(new { isValid = true, fileName = imageBackground.Name, imgBase64 = ImageBasej64 });
        }


        [HttpPost]
        public IActionResult RemoveBackground(ImageBackground imageBackground)
        {

            var BackgroundRemoveArray = imageBackground.RemoveColorRGB;
            var lengthString = BackgroundRemoveArray.Length;
            var arraySubString = BackgroundRemoveArray.Substring(1, lengthString - 2);
            imageBackground.RemoveColorRGB = arraySubString;

            var ImageBasej64 = _LoadAndModifyImage.RemoveBackground(imageBackground, arraySubString);


            return Json(new { isValid = true, fileName = imageBackground.Name, imgBase64 = ImageBasej64 });

        }

        [HttpPost]

        public async Task<IActionResult> SaveImage(ImageBackground imageBackground)
        {

            var logoSizeRatio = new LogoSizeAndAspectRatio();

            //string uploadsFolder = "C:\\Users\\domin\\OneDrive\\Desktop\\Images_Asp\\";
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            string uploads = Path.Combine(uploadsFolder, imageBackground.FileData.FileName);
            var separator = Path.DirectorySeparatorChar.ToString();


            var fileName = imageBackground.FileData.FileName;
            fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
            fileName = fileName + "_400px.png";


            var pathtoFileToSend = (uploadsFolder + separator + fileName);

            if (imageBackground.FileData.Length > 0)
            {

                using (Stream fileStream = new FileStream(uploads, FileMode.Create))
                {
                    await imageBackground.FileData.CopyToAsync(fileStream);
                }

                string ghostScriptPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Ghostscript");

                MagickReadSettings settings = new MagickReadSettings();
                settings.ColorSpace = ColorSpace.sRGB;
                settings.Density = new Density(96);

                //MagickNET.SetGhostscriptDirectory(@"C:\MyProgram\Ghostscript");
                MagickNET.SetGhostscriptDirectory(ghostScriptPath);

                MagickImage _image = new MagickImage();
                _image.Read(uploads, settings);
                _image.Resize(400, 0);

                _image.Write(pathtoFileToSend);

                _image.Dispose();

            }


            string fileToSend = Convert.ToBase64String(System.IO.File.ReadAllBytes(pathtoFileToSend));



            byte[] imageArray = System.IO.File.ReadAllBytes(pathtoFileToSend);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);


            return Json(new { isValid = true, fileName = fileName, imgBase64 = base64ImageRepresentation });
        }


        //private static MagickImage ChangeWhiteColor(MagickImage Image, int fuzz)
        //{
        //    Image.ColorFuzz = new Percentage(fuzz);
        //    Image.Transparent();
        //    Image.Opaque(MagickColor.FromRgb((byte)255, (byte)255, (byte)255), MagickColors.None);
        //    return Image;
        //}


        private static string SubstringBase64Image(string data)
        {
            string strStart = ",";
            string strEnd = "\"";
            int Start, End;

            Start = data.IndexOf(strStart, 20) + strStart.Length;
            End = data.IndexOf(strEnd, Start);
            End = data.Length;


            var Base64String = data.Substring(Start, End - Start);

            return Base64String;
        }



    }
}
