using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MimeKit;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repo;
using WebPreisBerechnungAuB.Services;
using System.Security.Cryptography;
using System.Drawing;
using NuGet.Configuration;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Controllers
{
    public class TextilController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGetFromDB _getFromDB;
        private readonly Ihelper _helper;

        public TextilController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._userManager = userManager;
            this._webHostEnvironment = webHostEnvironment;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._helper = new helper(_context, userManager);
        }

        public IActionResult loadArticelTextil()
        {





            List<ArticleTextil> mainArticelList = new List<ArticleTextil>();


            string textFile = "C:\\Users\\domin\\Downloads\\AT_Major_09_2023.csv";

            // Read file using StreamReader. Reads file line by line
            using (StreamReader file = new StreamReader(textFile))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    char[] spearator = { ';' };
                    Int32 count = 104;

                    // Using the Method
                    String[] strlist = ln.Split(spearator,
                           count, StringSplitOptions.None);



                    if (counter == 10)
                    {
                        break;
                    }

                    //Console.WriteLine(ln);
                    counter++;
                }
                file.Close();

            }


            return View();
        }

        public IActionResult Index(string search)
        {

            List<ArticelMainViewModel> mainArticelList = new List<ArticelMainViewModel>();

            if (search == null)
            {
                var query = _context.Products
                                   .Where(p => _context.Products
                                                      .GroupBy(p => p.CatalogNr)
                                                      .Select(g => g.Min(p => p.ArticleNr))
                                                      .Contains(p.ArticleNr))
                                   .OrderBy(p => p.Brand) // Fügen Sie eine Sortierung hinzu, um konsistente Ergebnisse zu gewährleisten
                                   .Skip(0)  // Überspringt die ersten 100 Datensätze
                                   .Take(1000)  // Nimmt die nächsten 100 Datensätze
                                   .ToList();

                foreach (var item in query)
                {

                    mainArticelList.Add(new ArticelMainViewModel(item.Description, item.Brand, item.CatalogNr));
                }

                List<string> uniqueBrandListe = _context.Products.Select(p => p.Brand).Distinct().ToList();

                mainArticelList.FirstOrDefault().BrandListUnique = uniqueBrandListe;

            }

            string searchName = "";
            string searchAttribute = "";



            if (search != null)
            {
                string[] SearchArray = search.Split('|');
                searchName = SearchArray[0];
                searchAttribute = SearchArray[1];

            }



            if (searchName == "Brand")
            {
                var query = _context.Products
                                    .Where(p => p.Brand == searchAttribute && _context.Products.GroupBy(p => p.CatalogNr)
                                    .Select(g => g.Min(p => p.ArticleNr))
                                    .Contains(p.ArticleNr))
                                    .OrderBy(p => p.Brand) // Sort by Brand for consistent results
                                    .Skip(0)  // Skip the first 0 records (could be omitted)
                                    .Take(1000)  // Take the first 1000 records
                                    .ToList();


                foreach (var item in query)
                {

                    mainArticelList.Add(new ArticelMainViewModel(item.Description, item.Brand, item.CatalogNr));
                }

                List<string> uniqueBrandListe = _context.Products.Select(p => p.Brand).Distinct().ToList();

                mainArticelList.FirstOrDefault().BrandListUnique = uniqueBrandListe;
            }

            return View(mainArticelList);
        }

        //public IActionResult Index()
        //{
        //    List<ArticelMain> mainArticelList = new List<ArticelMain>();




        //    string textFile = "C:\\Users\\domin\\Downloads\\articleWithoutDupplicates.csv";

        //    // Read file using StreamReader. Reads file line by line
        //    using (StreamReader file = new StreamReader(textFile))
        //    {
        //        int counter = 0;
        //        string ln;

        //        while ((ln = file.ReadLine()) != null)
        //        {
        //            char[] spearator = { ',' };
        //            Int32 count = 3;

        //            // Using the Method
        //            String[] strlist = ln.Split(spearator,
        //                   count, StringSplitOptions.None);



        //            mainArticelList.Add(new ArticelMain(strlist[0], strlist[1], strlist[2]));



        //            //Console.WriteLine(ln);
        //            counter++;
        //        }
        //        file.Close();

        //    }





        //    return View(mainArticelList);
        //}

        public IActionResult DetailSite(string catalogNr)
        {


            List<Product> product = _context.Products
                .Include(x => x.Color)
                .Where(x => x.CatalogNr == catalogNr)
                .ToList();

            var article = new Article();

            article.Name = product.FirstOrDefault().Description;
            article.Price = product.Min(x => x.EK);
            article.CatalogNr = product.FirstOrDefault().CatalogNr;


            var description = product.FirstOrDefault().LongDescription;

            char[] spearator = { '|' };
            // Int32 count = 21;

            // Using the Method
            String[] descriptionlist = description.Split(spearator, StringSplitOptions.None);


            foreach (var item in descriptionlist)
            {
                article.Descriptions.Add(item);

            }







            var distinctObjects = product.GroupBy(obj => new { obj.Color.Color1, obj.Color.HexCol1 })
                                         .Select(group => group.First())
                                         .ToList();



            foreach (var item in distinctObjects)
            {

                article.ArticleColors.Add(new ArticleColor(item.Color.Color1, "#" + item.Color.HexCol1));


            }




            List<AttributeArticle> attributeList = new List<AttributeArticle>();




            attributeList.Add(new AttributeArticle("Grammatur in g/m²:", product.FirstOrDefault().Grammage));
            attributeList.Add(new AttributeArticle("Pflegehinweis:", product.FirstOrDefault().CareInstruction));


            article.Attributes = attributeList;





            return View(article);
        }
        [HttpPost]
        public IActionResult loadProductSize(string color, string catalogNr)
        {
            List<Product> ProductColorSize = new List<Product>();


            ProductColorSize = _context.Products
                .Where(x => x.Color.Color1 == color)
                .Where(x => x.CatalogNr == catalogNr)
                .Include(x => x.Color)
                .ToList();

            //C:\Users\domin\source\repos\braendle90\WebPreisBerechnung2022\WebPreisBerechnungAuB\wwwroot\inventory\stockfile.csv


            string textFile = "C:\\Users\\domin\\source\\repos\\braendle90\\WebPreisBerechnung2022\\WebPreisBerechnungAuB\\wwwroot\\inventory\\stockfile.csv";

            if (System.IO.File.Exists(textFile))
            {
                // Read file using StreamReader. Reads file line by line
                using (StreamReader file = new StreamReader(textFile))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        char[] spearator = { ';' };
                        Int32 count = 3;

                        // Using the Method
                        String[] strlist = ln.Split(spearator,
                               count, StringSplitOptions.None);


                        foreach (var item in ProductColorSize)
                        {

                            if (item.ArticleNr == strlist[0])
                            {
                                Inventory inventory = new Inventory();
                                inventory.Stock = int.Parse(strlist[1]);
                                item.Inventory = inventory;

                                var test123 = inventory;

                            }

                        }

                        var test = ProductColorSize;

                        counter++;
                    }
                    file.Close();

                }
            }





            //foreach (var item in ProductColorSize)
            //{
            //    article.ArticleSizes.Add(new ArticleSize(item.Size, item.Color.Color1, item.Color.HexCol1, 123, 0, item.Weight.ToString()));

            //}

            // string jsonString = JsonSerializer.Serialize(ProductColorSize);

            string text = "";

            foreach (var item in ProductColorSize)
            {
                string tableRowA = "<tr>";
                string tableDataFirst = "<td";
                string tableDataA = "<td>";
                string tableRowE = "</tr>";
                string tableDataE = "</td>";

                //ColorField
                string text1 = tableRowA + tableDataFirst + " style='width: 3em; height: 3em;' bgcolor='" + item.Color.HexCol1 + "'" + tableDataE;
                //Size
                string text2 = tableDataA + item.Size + tableDataE;
                //Lagerstand
                string text3 = tableDataA + item.Inventory.Stock + "    "+ item.ArticleNr + tableDataE;
                //Gewicht
                string text4 = tableDataA + item.Weight + tableDataE + tableRowE;

                text = text + text1 + text2 + text3 + text4;

            }

            return Json(new { isValid = true, jsonString = text });

        }

        public IActionResult fillDatabasefromExel()
        {


            string textFile = "C:\\Users\\domin\\Downloads\\TextilSplitColums.csv";

            if (System.IO.File.Exists(textFile))
            {
                // Read file using StreamReader. Reads file line by line
                using (StreamReader file = new StreamReader(textFile))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        char[] spearator = { ';' };
                        Int32 count = 21;

                        // Using the Method
                        String[] strlist = ln.Split(spearator,
                               count, StringSplitOptions.None);


                        //  "1000283768;AR019;7.88;White;;;;F5F4F8;;;;50 x 80 cm;ARTG;0.45;AR019_White.jpg;Bath Mat;Badematte | Hergestellt aus türkischer Baumwolle;100% Baumwolle;1000 g/m²;40 °C waschbar|Bügeln erlaubt;Badematten;"

                        var test = double.Parse(strlist[2], CultureInfo.InvariantCulture);

                        var ProductColor = new ProductColor
                        {

                            Color1 = strlist[3],
                            Color2 = strlist[4],
                            Color3 = strlist[5],
                            Color4 = strlist[6],
                            HexCol1 = strlist[7],
                            HexCol2 = strlist[8],
                            HexCol3 = strlist[9],
                            HexCol4 = strlist[10],

                        };

                        var product = new Product
                        {
                            ArticleNr = strlist[0],
                            CatalogNr = strlist[1],
                            EK = double.Parse(strlist[2], CultureInfo.InvariantCulture),
                            Color = ProductColor,
                            Size = strlist[11],
                            Brand = strlist[12],
                            Weight = double.Parse(strlist[13], CultureInfo.InvariantCulture),
                            PictureName = strlist[14],
                            Description = strlist[15],
                            LongDescription = strlist[16],
                            Consistence = strlist[17],
                            Grammage = strlist[18],
                            CareInstruction = strlist[19],
                            ProductType = strlist[20].Trim(new Char[] { ' ', ';', '.' })
                        };

                        var existingProduct = _context.Products.FirstOrDefault(p => p.ArticleNr == product.ArticleNr)
;
                        if (existingProduct == null)
                        {
                            _context.Add(product);
                            _context.SaveChanges();
                        }
                        else
                        {

                            // Behandeln Sie den Fall, dass das Produkt bereits existiert (z.B. Fehlermeldung, Update-Logik, etc.)
                        }

                        counter++;
                    }
                    file.Close();

                }
            }

            return View("Index");
        }

    }
}
