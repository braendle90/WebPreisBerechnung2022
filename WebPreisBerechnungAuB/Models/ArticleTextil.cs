using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPreisBerechnungAuB.Models
{
    public  class ArticleTextil
    {

        [Key]
        public int ArticleNr { get; set; }
        [StringLength(50)]
        public string? CatalogNr { get; set; }
        [Column("EK")]
        public double? Ek { get; set; }
        public double? SinglePrice { get; set; }
        public double? CartonPrice { get; set; }
        [Column("_10CartonsPrice")]
        public double? _10cartonsPrice { get; set; }
        [Column("VK_BASIS_01")]
        public double? VkBasis01 { get; set; }
        [Column("VK_BASIS_05")]
        public double? VkBasis05 { get; set; }
        [Column("VK_BASIS_06")]
        public double? VkBasis06 { get; set; }
        [Column("VK_PLUS_01")]
        public double? VkPlus01 { get; set; }
        [Column("VK_PLUS_05")]
        public double? VkPlus05 { get; set; }
        [Column("VK_PLUS_06")]
        public double? VkPlus06 { get; set; }
        [Column("VK_100_01")]
        public double? Vk10001 { get; set; }
        [Column("VK_100_05")]
        public double? Vk10005 { get; set; }
        [Column("VK_100_06")]
        public double? Vk10006 { get; set; }
        [Column("VK_119_01")]
        public double? Vk11901 { get; set; }
        [Column("VK_119_05")]
        public double? Vk11905 { get; set; }
        [Column("VK_119_06")]
        public double? Vk11906 { get; set; }
        [Column("VK_120_01")]
        public double? Vk12001 { get; set; }
        [Column("VK_120_05")]
        public double? Vk12005 { get; set; }
        [Column("VK_120_06")]
        public double? Vk12006 { get; set; }
        [Column("VK_121_01")]
        public double? Vk12101 { get; set; }
        [Column("VK_121_05")]
        public double? Vk12105 { get; set; }
        [Column("VK_121_06")]
        public double? Vk12106 { get; set; }
        public long? QtyCarton { get; set; }
        [Column("color1")]
        public string? Color1 { get; set; }
        [Column("color2")]
        public string? Color2 { get; set; }
        [Column("color3")]
        public string? Color3 { get; set; }
        [Column("color4")]
        public string? Color4 { get; set; }
        [Column("hexcol1")]
        public string? Hexcol1 { get; set; }
        [Column("hexcol2")]
        public string? Hexcol2 { get; set; }
        [Column("hexcol3")]
        public string? Hexcol3 { get; set; }
        [Column("hexcol4")]
        public string? Hexcol4 { get; set; }
        public string? Size { get; set; }
        public string? Brand { get; set; }
        public byte? Discontinued { get; set; }
        public double? Weight { get; set; }
        public int? CatalogPageTexStyles { get; set; }
        public int? CatalogPageCorporateWear { get; set; }
        public int? CatalogPagePromotion { get; set; }
        public int? CatalogPageSportsWear { get; set; }
        public string? CatNrManufacturer { get; set; }
        public string? ArtNrManufacturer { get; set; }
        [Column("EAN")]
        public string? Ean { get; set; }
        public string? TariffNumber { get; set; }
        [StringLength(50)]
        public string? CountryOfOrigin { get; set; }
        public string? NewDate { get; set; }
        public string? PictureName { get; set; }
        public string? Description { get; set; }
        public string? LongDescription { get; set; }
        public string? MainCategory { get; set; }
        public string? SubCategory { get; set; }
        public string? Consistence { get; set; }
        public string? Grammage { get; set; }
        public string? CareInstruction { get; set; }
        public string? Product { get; set; }
        public string? Sleeve { get; set; }
        public string? Legs { get; set; }
        public string? Nature { get; set; }
        public string? Colourfulness { get; set; }
        public string? Function { get; set; }
        [Column("Making_Cachet")]
        public string? MakingCachet { get; set; }
        public string? Collections { get; set; }
        [Column("Collar_Neckline")]
        public string? CollarNeckline { get; set; }
        public string? Label { get; set; }
        public string? Material { get; set; }
        public string? Cutting { get; set; }
        public string? ShopNavigation { get; set; }
        public string? Workmanship { get; set; }
        public string? Improving { get; set; }
        public string? Mixture { get; set; }
        [Column("Details_CapType")]
        public string? DetailsCapType { get; set; }
        [Column("Details_Caps")]
        public string? DetailsCaps { get; set; }
        [Column("Details_CapSpecial")]
        public string? DetailsCapSpecial { get; set; }
        [Column("Details_CapLock")]
        public string? DetailsCapLock { get; set; }
        [Column("Details_Blanket")]
        public string? DetailsBlanket { get; set; }
        [Column("Details_Glove")]
        public string? DetailsGlove { get; set; }
        [Column("Details_Towels")]
        public string? DetailsTowels { get; set; }
        [Column("Details_Shirt")]
        public string? DetailsShirt { get; set; }
        [Column("Details_Trousers")]
        public string? DetailsTrousers { get; set; }
        [Column("Details_Hats")]
        public string? DetailsHats { get; set; }
        [Column("Details_Jackets")]
        public string? DetailsJackets { get; set; }
        [Column("Details_Pillow")]
        public string? DetailsPillow { get; set; }
        [Column("Details_Buttons")]
        public string? DetailsButtons { get; set; }
        [Column("Details_Bonnet")]
        public string? DetailsBonnet { get; set; }
        [Column("Details_Scarfs")]
        public string? DetailsScarfs { get; set; }
        [Column("Details_Umbrellas")]
        public string? DetailsUmbrellas { get; set; }
        [Column("Details_UmbrellaHandle")]
        public string? DetailsUmbrellaHandle { get; set; }
        [Column("Details_Shoes")]
        public string? DetailsShoes { get; set; }
        [Column("Details_Pinafore")]
        public string? DetailsPinafore { get; set; }
        [Column("Details_Bags")]
        public string? DetailsBags { get; set; }
        [Column("Details_Underwear")]
        public string? DetailsUnderwear { get; set; }
        [Column("Details_Saleshelper")]
        public string? DetailsSaleshelper { get; set; }
        [Column("Details_Pullover")]
        public string? DetailsPullover { get; set; }
        [Column("Details_StuffedAnimals")]
        public string? DetailsStuffedAnimals { get; set; }
        [Column("Details_SweatshirtsJackets")]
        public string? DetailsSweatshirtsJackets { get; set; }
        [Column("Details_TShirts")]
        public string? DetailsTshirts { get; set; }
        [Column("Details_PoloShirts")]
        public string? DetailsPoloShirts { get; set; }
        [Column("Details_Blouses")]
        public string? DetailsBlouses { get; set; }
        [Column("Details_Ties")]
        public string? DetailsTies { get; set; }
        [Column("Details_Skirts")]
        public string? DetailsSkirts { get; set; }
        [Column("Details_Socks")]
        public string? DetailsSocks { get; set; }
        [Column("Details_Vests")]
        public string? DetailsVests { get; set; }
        [Column("Partner_Article")]
        public string? PartnerArticle { get; set; }
    }
}
