using System;
using System.ComponentModel.DataAnnotations;

namespace WebPreisBerechnungAuB.Models
{
    public class Product
    {
        [Key]
        public string ArticleNr { get; set; }
        public double EK { get; set; }
        public ProductColor Color { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Consistence { get; set; }
        public string Grammage { get; set; }
        public string CareInstruction { get; set; }
        public string ProductType { get; set; }
        public double Weight { get; set; }
        public string Material { get; set; }
        public string CatalogNr { get; set; }

        public Inventory Inventory { get; set; }
    }

}


//public string CatalogNr { get; set; }
//public decimal EK { get; set; }
//public decimal SinglePrice { get; set; }
//public decimal CartonPrice { get; set; }
//public decimal Cartons10Price { get; set; }
//public decimal VK_BASIS_01 { get; set; }
//public decimal VK_BASIS_05 { get; set; }
//public decimal VK_BASIS_06 { get; set; }
//public decimal VK_PLUS_01 { get; set; }
//public decimal VK_PLUS_05 { get; set; }
//public decimal VK_PLUS_06 { get; set; }
//public decimal VK_100_01 { get; set; }
//public decimal VK_100_05 { get; set; }
//public decimal VK_100_06 { get; set; }
//public decimal VK_119_01 { get; set; }
//public decimal VK_119_05 { get; set; }
//public decimal VK_119_06 { get; set; }
//public decimal VK_120_01 { get; set; }
//public decimal VK_120_05 { get; set; }
//public decimal VK_120_06 { get; set; }
//public decimal VK_121_01 { get; set; }
//public decimal VK_121_05 { get; set; }
//public decimal VK_121_06 { get; set; }
//public int QtyCarton { get; set; }
//public string Color1 { get; set; }
//public string Color2 { get; set; }
//public string Color3 { get; set; }
//public string Color4 { get; set; }
//public string HexCol1 { get; set; }
//public string HexCol2 { get; set; }
//public string HexCol3 { get; set; }
//public string HexCol4 { get; set; }
//public string Size { get; set; }
//public string Brand { get; set; }
//public bool Discontinued { get; set; } = false;
//public decimal Weight { get; set; }
//public string CatalogPageTexStyles { get; set; }
//public string CatalogPageCorporateWear { get; set; }
//public string CatalogPagePromotion { get; set; }
//public string CatalogPageSportsWear { get; set; }
//public string CatNrManufacturer { get; set; }
//public string ArtNrManufacturer { get; set; }
//public string EAN { get; set; }
//public string TariffNumber { get; set; }
//public string CountryOfOrigin { get; set; }
//public DateTime NewDate { get; set; }
//public string PictureName { get; set; }
//public string Description { get; set; }
//public string LongDescription { get; set; }
//public string MainCategory { get; set; }
//public string SubCategory { get; set; }
//public string Consistence { get; set; }
//public string Grammage { get; set; }
//public string CareInstruction { get; set; }
//public string ProductType { get; set; }
//public string Sleeve { get; set; }
//public string Legs { get; set; }
//public string Nature { get; set; }
//public string Colourfulness { get; set; }
//public string Function { get; set; }
//public string MakingCachet { get; set; }
//public string Collections { get; set; }
//public string CollarNeckline { get; set; }
//public string Label { get; set; }
//public string Material { get; set; }
//public string Cutting { get; set; }
//public string ShopNavigation { get; set; }
//public string Workmanship { get; set; }
//public string Improving { get; set; }
//public string Mixture { get; set; }
//public string Details_CapType { get; set; }
//public string Details_Caps { get; set; }
//public string Details_CapSpecial { get; set; }
//public string Details_CapLock { get; set; }
//public string Details_Blanket { get; set; }
//public string Details_Glove { get; set; }
//public string Details_Towels { get; set; }
//public string Details_Shirt { get; set; }
//public string Details_Trousers { get; set; }
//public string Details_Hats { get; set; }
//public string Details_Jackets { get; set; }
//public string Details_Pillow { get; set; }
//public string Details_Buttons { get; set; }
//public string Details_Bonnet { get; set; }
//public string Details_Scarfs { get; set; }
//public string Details_Umbrellas { get; set; }
//public string Details_UmbrellaHandle { get; set; }
//public string Details_Shoes { get; set; }
//public string Details_Pinafore { get; set; }
//public string Details_Bags { get; set; }
//public string Details_Underwear { get; set; }
//public string Details_Saleshelper { get; set; }
//public string Details_Pullover { get; set; }
//public string Details_StuffedAnimals { get; set; }
//public string Details_SweatshirtsJackets { get; set; }
//public string Details_TShirts { get; set; }
//public string Details_PoloShirts { get; set; }
//public string Details_Blouses { get; set; }
//public string Details_Ties { get; set; }
//public string Details_Skirts { get; set; }
//public string Details_Socks { get; set; }
//public string Details_Vests { get; set; }
//public string Partner_Article { get; set; }
