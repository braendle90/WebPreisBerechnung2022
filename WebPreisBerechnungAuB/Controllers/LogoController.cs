using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Controllers
{
    [Authorize]
    public class LogoController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGetFromDB _getFromDB;
        private readonly Ihelper _helper;

        public LogoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._userManager = userManager;
            this._webHostEnvironment = webHostEnvironment;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._helper = new helper(_context, userManager);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? id)
        {



            var user = await _userManager.GetUserAsync(User);

            LogoVM modelVm = await _getFromDB.loadallOplAndCreateVm(id, user);


            return View(modelVm);
        }

        public async Task<IActionResult> ShowLogo()
        {
            var user = await _userManager.GetUserAsync(User);

            LogoVM modelVm = await _getFromDB.loadAllLogosFromUserAndCreateLogoVM(user);

            modelVm.ShowUserLogos = true;


            return View("Index", modelVm);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id, string offerId, bool showUserLogos)
        {
            var user = await _userManager.GetUserAsync(User);
            var colorList = await _getFromDB.loadAllColor();

            var checkboxChargeList = await _context.ExtraCharge
                .Where(x => x.ChargeTyp == "Logo")
                .ToListAsync();
            var listExtraChargeLoad = new List<ExtraChargeList>();

            if (id == 0)
            {

                foreach (var item in checkboxChargeList)
                {
                    var model = new ExtraChargeList
                    {
                        ExtraCharge = item,
                        IsSelected = false,
                    };

                    if (item.IsSelected)
                    {
                        model.IsSelected = true;
                    }

                    listExtraChargeLoad.Add(model);

                }

            }

            LogoVM vmModel = new();

            var getOfferid = await _context.Logos.FindAsync(id);
            var test = await _getFromDB.loadLogoById(id);

            if (getOfferid != null)
            {
                vmModel.ColorList = colorList;
                vmModel.OfferId = getOfferid.OfferId;

            }
            else
            {
                vmModel.ColorList = colorList;
                vmModel.OfferId = offerId;
            }

            if (showUserLogos)
            {
                vmModel.ShowUserLogos = true;
            }

            if (id == 0)
            {
                var colorModelNew = new Color();
                var logoModelNew = new Logo
                {
                    Color = colorModelNew,
                };
                vmModel.ColorId = 0;
                vmModel.SelectColorList = new List<SelectListItem>();

                foreach (var color in vmModel.ColorList)
                {
                    vmModel.SelectColorList.Add(new SelectListItem { Text = color.ColorName, Value = color.Id.ToString() });

                }
                vmModel.Logo = logoModelNew;
                vmModel.ExtraChargeListCheckbox = checkboxChargeList;
                vmModel.ExtraChargeListsModel = listExtraChargeLoad;
                return View("_EditPartialLogo", vmModel);
            }

            else
            {

                vmModel.Logo = await _getFromDB.loadLogoById(id);
                //vmModel.ExtraChargeListCheckbox = listExtraChargeLoad;
                vmModel.ExtraChargeListsModel = _context.ExtraChargeList
                    .Include(x => x.ExtraCharge)
                    .Where(x => x.Logo.Id == id).ToList();

            }

            //demo if the view change the selected 1 farbig to 2 or 3 farbig
            vmModel.ColorId = getOfferid.Color.Id;
            vmModel.SelectColorList = new List<SelectListItem>();

            foreach (var color in vmModel.ColorList)
            {
                vmModel.SelectColorList.Add(new SelectListItem { Text = color.ColorName, Value = color.Id.ToString() });

            }




            return View("_EditPartialLogo", vmModel);
        }


        [HttpPost]
        public async Task<IActionResult> SaveImage(IFormFile file)
        {

            var logoSizeRatio = new LogoSizeAndAspectRatio();

            //string uploadsFolder = "C:\\Users\\domin\\OneDrive\\Desktop\\Images_Asp\\";
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            string uploads = Path.Combine(uploadsFolder, file.FileName);
            var separator = Path.DirectorySeparatorChar.ToString();




            if (file.Length > 0)
            {

                using (Stream fileStream = new FileStream(uploads, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                string ghostScriptPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Ghostscript");

                MagickReadSettings settings = new MagickReadSettings();
                settings.ColorSpace = ColorSpace.sRGB;
                settings.Density = new Density(72);

                //MagickNET.SetGhostscriptDirectory(@"C:\MyProgram\Ghostscript");
                MagickNET.SetGhostscriptDirectory(ghostScriptPath);

                MagickImage _image = new MagickImage();
                _image.Read(uploads, settings);
                _image.Resize(400, 0);

                _image.Write(uploadsFolder + separator + file.FileName + ".png");


                logoSizeRatio.width = _image.Width;

                logoSizeRatio.height = _image.Height;
                //remove the file that is uploaded so that only the png file is available
                //DeleteFileFromFolder(filePath);



                logoSizeRatio.CalcRatio(_image.Height, _image.Width);

                _image.Dispose();

            }

            var pathtoFileToSend = (uploadsFolder + separator + file.FileName + ".png");

            string fileToSend = Convert.ToBase64String(System.IO.File.ReadAllBytes(pathtoFileToSend));


            string jsonString = JsonSerializer.Serialize(logoSizeRatio);




            return Json(new { isValid = true, fileToSend = fileToSend, jsonString = jsonString });
        }


        //public void DeleteFileFromFolder(string strFileFullPath)
        //{

        //    if (File.Exists(strFileFullPath))
        //    {
        //        File.Delete(strFileFullPath);
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("OfferId,ColorId,Logo,ExtraChargeId,ExtraCharge,ExtraChargeList,ShowUserLogos,Image,ExtraChargeListsModel")] LogoVM model)
        {
            var user = await _userManager.GetUserAsync(User);
            var color = await _context.Colors.FindAsync(model.ColorId);
            Logo modelToUpdate = model.Logo;

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            var separator = Path.DirectorySeparatorChar.ToString();

            var newExtraChargeList = new List<ExtraChargeList>();

            if (model.Image != null)
            {

                string guid = Guid.NewGuid().ToString();
                //@"wwwroot\img\" + guid + ".png"
                // string filePath = "C:\\Users\\domin\\OneDrive\\Desktop\\Images_Asp\\" + guid + ".png";
                //string filePath = @"wwwroot\img\" + guid + ".png";
                string filePath = uploadsFolder + separator + guid + ".png";


                var file = new Models.File
                {
                    Name = model.Logo.LogoName,
                    FilePath = "/img/" + guid + ".png",
                };

                model.Logo.File = file;

                byte[] bytes = Convert.FromBase64String(model.Image.Split(',')[1]);


                FileStream stream = new FileStream(filePath, FileMode.Create);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                TempData["Success"] = "Image uploaded successfully";

            }

           model.Logo.LogoSurfaceSize = (model.Logo.SurfaceHight * model.Logo.SurfaceWidht);

            LogoVM modelVm;

            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    model.Logo.Color = color;
                    model.Logo.OfferId = model.OfferId;
                    model.Logo.User = user;
                    _context.Logos.Add(model.Logo);
                    await _context.SaveChangesAsync();

                    await _helper.CreateExtraChargeList(model);



                    //foreach (var item in model.ExtraChargeListsModel)
                    //{
                    //    var newExtraCharge = new ExtraChargeList
                    //    {
                    //        ExtraCharge = _context.ExtraCharge.Find(item.ExtraCharge.Id),
                    //        IsSelected = item.IsSelected,
                    //        Logo = model.Logo,
                    //    };

                    //    newExtraChargeList.Add(newExtraCharge);

                    //}

                    //_context.AddRange(newExtraChargeList);
                    //_context.SaveChanges();

                }

                else
                {
                    var updateExtraChargeList = new List<ExtraChargeList>();

                    modelToUpdate.Color = color;
                    modelToUpdate.Color.ColorName = color.ColorName;
                    modelToUpdate.OfferId = model.OfferId;

                    modelToUpdate.LogoName = model.Logo.LogoName;
                    model.Logo.User = user;
                    modelToUpdate.Id = id;

                    _context.Update(modelToUpdate);
                    await _context.SaveChangesAsync();

                    await _helper.updateExtraChargeList(model);

                    //foreach (var item in model.ExtraChargeListsModel)
                    //{

                    //    var extraChargeListLoading = await _context.ExtraChargeList
                    //        .Include(x => x.ExtraCharge)
                    //        .Where(x => x.Id == item.Id)
                    //        .FirstOrDefaultAsync();

                    //    extraChargeListLoading.IsSelected = item.IsSelected;
                    //    updateExtraChargeList.Add(extraChargeListLoading);
                    //}

                    //_context.ExtraChargeList.UpdateRange(updateExtraChargeList);
                    //await _context.SaveChangesAsync();
                }



                //erstelle methode in der Helper Klasse
                if (model.ShowUserLogos)
                {
                    modelVm = await _getFromDB.loadallOplAndCreateVmFromUser(user);
                    modelVm.ShowUserLogos = model.ShowUserLogos;
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ShowLogoPartial", modelVm) });
                }


                modelVm = await _getFromDB.loadallOplAndCreateVm(model.OfferId, user);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllLogoPartial", modelVm) });



            }

            modelVm = await _getFromDB.loadallOplAndCreateVm(model.OfferId, user);


            //erstelle methode in der Helper Klasse
            if (model.ShowUserLogos)
            {
                modelVm.ShowUserLogos = model.ShowUserLogos;
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ShowLogoPartial", modelVm) });
            }


            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllLogoPartial", modelVm) });
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _getFromDB.loadLogoById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, bool showUserLogos)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = await _getFromDB.loadLogoById(id);

            await _getFromDB.removeLogoFromPositionLogoByLogoIdAndUser(id, user);


            var modelVm = await _getFromDB.loadallOplAndCreateVm(model.OfferId, user);


            if (showUserLogos)
            {
                modelVm.ShowUserLogos = showUserLogos;
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ShowLogoPartial", modelVm) });

            }

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllLogoPartial", modelVm) });


        }



        private bool TransactionModelExists(int id)
        {
            return _context.Logos.Any(e => e.Id == id);
        }

    }
}
