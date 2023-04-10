using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Repo;
using System.Text.Json;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebPreisBerechnungAuB.Controllers
{
    public class DesignerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DesignerController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
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
        public async Task<IActionResult> SaveImage(string data)
        {

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            // string uploads = Path.Combine(uploadsFolder, file.FileName);
            var separator = Path.DirectorySeparatorChar.ToString();

            string strStart = ",";
            string strEnd = "\"";


            int Start, End;

            Start = data.IndexOf(strStart, 20) + strStart.Length;
            End = data.IndexOf(strEnd, Start);
            End = data.Length;   
         

            var Base64String = data.Substring(Start, End - Start);

            if (data.Length > 0)
            {

       

                string ghostScriptPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Ghostscript");

                MagickReadSettings settings = new MagickReadSettings();
                settings.ColorSpace = ColorSpace.sRGB;
                settings.Density = new Density(72);

                //MagickNET.SetGhostscriptDirectory(@"C:\MyProgram\Ghostscript");
                MagickNET.SetGhostscriptDirectory(ghostScriptPath);

                var _image = MagickImage.FromBase64(Base64String);
               
                _image.Resize(400, 0);

                _image.Write(uploadsFolder + separator + "BgRemoved" + ".png");


                //remove the file that is uploaded so that only the png file is available
                //DeleteFileFromFolder(filePath);

                _image.Dispose();

            }

            //var logoSizeRatio = new LogoSizeAndAspectRatio();

            ////string uploadsFolder = "C:\\Users\\domin\\OneDrive\\Desktop\\Images_Asp\\";
            //string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            //string uploads = Path.Combine(uploadsFolder, "testName.png");
            //var separator = Path.DirectorySeparatorChar.ToString();


            byte[] imageArray = System.IO.File.ReadAllBytes(uploadsFolder + separator + "BgRemoved" + ".png");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);


            return Json(new { isValid = true, imgBase64 = base64ImageRepresentation });
        }
    }
}
