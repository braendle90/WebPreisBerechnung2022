﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repo;

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
        public IActionResult Index()
        {




            return View();
        }

        public IActionResult DetailSite()
        {

            var article = new Article();

            article.Name = "Imperial T-Shirt";
            article.Price = 2.3;



            article.Descriptions.Add("Verstärkendes Nackenband");
            article.Descriptions.Add("Kragenbündchen mit Elasthan");
            article.Descriptions.Add("Schlauchware");
            article.Descriptions.Add("Heavy-Jersey");




            article.ArticleColors.Add(new ArticleColor("Ancient Pink", "#9C6169"));
            article.ArticleColors.Add(new ArticleColor(" Pink", "#707070"));
            article.ArticleColors.Add(new ArticleColor("Ancient Pink", "#9C6169"));
            article.ArticleColors.Add(new ArticleColor(" Pink", "#707070"));
            article.ArticleColors.Add(new ArticleColor("Ancient Pink", "#9C6169"));
            article.ArticleColors.Add(new ArticleColor(" Pink", "#707070"));
            article.ArticleColors.Add(new ArticleColor("Ancient Pink", "#9C6169"));
            article.ArticleColors.Add(new ArticleColor(" Pink", "#707070"));
            article.ArticleColors.Add(new ArticleColor("Ancient Pink", "#9C6169"));
            article.ArticleColors.Add(new ArticleColor(" Pink", "#707070"));


            List<ArticleColor> articelList = new List<ArticleColor>();


            List<AttributeArticle> attributeList = new List<AttributeArticle>();




            attributeList.Add(new AttributeArticle("Grammatur in g/m²:", "190 g/m²"));
            attributeList.Add(new AttributeArticle("Pflegehinweis:", "40 °C waschbar\r\nBügeln erlaubt"));


            article.Attributes = attributeList;



            return View(article);
        }


        public Article DemoArticle()
        {


            var article = new Article();

            article.Name = "Imperial T-Shirt";
            article.Price = 2.3;
            article.Manufacturer = "SOL´S";

            article.Descriptions.Add("Verstärkendes Nackenband");
            article.Descriptions.Add("Kragenbündchen mit Elasthan");
            article.Descriptions.Add("Schlauchware");
            article.Descriptions.Add("Heavy-Jersey");






            return article;

        }



    }
}
