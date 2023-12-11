using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class updatePrductList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtNrManufacturer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartonPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cartons10Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatNrManufacturer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatalogNr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatalogPageCorporateWear",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatalogPagePromotion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatalogPageSportsWear",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatalogPageTexStyles",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CollarNeckline",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Collections",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Colourfulness",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cutting",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Bags",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Blanket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Blouses",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Bonnet",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Buttons",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_CapLock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_CapSpecial",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_CapType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Caps",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Glove",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Hats",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Jackets",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Pillow",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Pinafore",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_PoloShirts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Pullover",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Saleshelper",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Scarfs",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Shirt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Shoes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Skirts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Socks",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_StuffedAnimals",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_SweatshirtsJackets",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_TShirts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Ties",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Towels",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Trousers",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_UmbrellaHandle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Umbrellas",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Underwear",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details_Vests",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discontinued",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EAN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HexCol1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HexCol2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HexCol3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HexCol4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Improving",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Legs",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MakingCachet",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Mixture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Nature",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NewDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Partner_Article",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QtyCarton",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopNavigation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SinglePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sleeve",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TariffNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_100_01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_100_05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_100_06",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_119_01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_119_05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_119_06",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_120_01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_120_05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_120_06",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_121_01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_121_05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_121_06",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_BASIS_01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_BASIS_05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_BASIS_06",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_PLUS_01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_PLUS_05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VK_PLUS_06",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Workmanship",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexCol1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexCol2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexCol3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexCol4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductColor_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductColor_ColorId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ArtNrManufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CartonPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cartons10Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CatNrManufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogNr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogPageCorporateWear",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogPagePromotion",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogPageSportsWear",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogPageTexStyles",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollarNeckline",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Collections",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colourfulness",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cutting",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Bags",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Blanket",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Blouses",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Bonnet",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Buttons",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_CapLock",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_CapSpecial",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_CapType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Caps",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Glove",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Hats",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Jackets",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Pillow",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Pinafore",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_PoloShirts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Pullover",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Saleshelper",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Scarfs",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Shirt",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Shoes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Skirts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Socks",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_StuffedAnimals",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_SweatshirtsJackets",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_TShirts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Ties",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Towels",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Trousers",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_UmbrellaHandle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Umbrellas",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Underwear",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details_Vests",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Discontinued",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EAN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HexCol1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HexCol2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HexCol3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HexCol4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Improving",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Legs",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCategory",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MakingCachet",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mixture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nature",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NewDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Partner_Article",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QtyCarton",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShopNavigation",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SinglePrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Sleeve",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TariffNumber",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_100_01",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_100_05",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_100_06",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_119_01",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_119_05",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_119_06",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_120_01",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_120_05",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_120_06",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_121_01",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_121_05",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_121_06",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_BASIS_01",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_BASIS_05",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_BASIS_06",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_PLUS_01",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_PLUS_05",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VK_PLUS_06",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Workmanship",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
