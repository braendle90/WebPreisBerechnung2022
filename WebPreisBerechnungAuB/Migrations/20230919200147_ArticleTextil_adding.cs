using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class ArticleTextil_adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleTextils",
                columns: table => new
                {
                    ArticleNr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogNr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EK = table.Column<double>(type: "float", nullable: true),
                    SinglePrice = table.Column<double>(type: "float", nullable: true),
                    CartonPrice = table.Column<double>(type: "float", nullable: true),
                    _10CartonsPrice = table.Column<double>(type: "float", nullable: true),
                    VK_BASIS_01 = table.Column<double>(type: "float", nullable: true),
                    VK_BASIS_05 = table.Column<double>(type: "float", nullable: true),
                    VK_BASIS_06 = table.Column<double>(type: "float", nullable: true),
                    VK_PLUS_01 = table.Column<double>(type: "float", nullable: true),
                    VK_PLUS_05 = table.Column<double>(type: "float", nullable: true),
                    VK_PLUS_06 = table.Column<double>(type: "float", nullable: true),
                    VK_100_01 = table.Column<double>(type: "float", nullable: true),
                    VK_100_05 = table.Column<double>(type: "float", nullable: true),
                    VK_100_06 = table.Column<double>(type: "float", nullable: true),
                    VK_119_01 = table.Column<double>(type: "float", nullable: true),
                    VK_119_05 = table.Column<double>(type: "float", nullable: true),
                    VK_119_06 = table.Column<double>(type: "float", nullable: true),
                    VK_120_01 = table.Column<double>(type: "float", nullable: true),
                    VK_120_05 = table.Column<double>(type: "float", nullable: true),
                    VK_120_06 = table.Column<double>(type: "float", nullable: true),
                    VK_121_01 = table.Column<double>(type: "float", nullable: true),
                    VK_121_05 = table.Column<double>(type: "float", nullable: true),
                    VK_121_06 = table.Column<double>(type: "float", nullable: true),
                    QtyCarton = table.Column<long>(type: "bigint", nullable: true),
                    color1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hexcol1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hexcol2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hexcol3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hexcol4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discontinued = table.Column<byte>(type: "tinyint", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    CatalogPageTexStyles = table.Column<int>(type: "int", nullable: true),
                    CatalogPageCorporateWear = table.Column<int>(type: "int", nullable: true),
                    CatalogPagePromotion = table.Column<int>(type: "int", nullable: true),
                    CatalogPageSportsWear = table.Column<int>(type: "int", nullable: true),
                    CatNrManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtNrManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consistence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grammage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sleeve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colourfulness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Making_Cachet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collections = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collar_Neckline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cutting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopNavigation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workmanship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Improving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mixture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_CapType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Caps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_CapSpecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_CapLock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Blanket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Glove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Towels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Shirt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Trousers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Hats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Jackets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Pillow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Buttons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Bonnet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Scarfs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Umbrellas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_UmbrellaHandle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Shoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Pinafore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Bags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Underwear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Saleshelper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Pullover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_StuffedAnimals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_SweatshirtsJackets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_TShirts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_PoloShirts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Blouses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Ties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Skirts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Socks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details_Vests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partner_Article = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTextils", x => x.ArticleNr);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTextils");
        }
    }
}
