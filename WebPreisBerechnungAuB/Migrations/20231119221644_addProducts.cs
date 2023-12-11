using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class addProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticelMainId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticelMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticelMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ArticleNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CatalogNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SinglePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartonPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cartons10Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_BASIS_01 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_BASIS_05 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_BASIS_06 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_PLUS_01 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_PLUS_05 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_PLUS_06 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_100_01 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_100_05 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_100_06 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_119_01 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_119_05 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_119_06 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_120_01 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_120_05 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_120_06 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_121_01 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_121_05 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VK_121_06 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexCol1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatNrManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtNrManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consistence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grammage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colourfulness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collections = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ArticleNr);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_ArticelMainId",
                table: "Files",
                column: "ArticelMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_ArticelMain_ArticelMainId",
                table: "Files",
                column: "ArticelMainId",
                principalTable: "ArticelMain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_ArticelMain_ArticelMainId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "ArticelMain");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Files_ArticelMainId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ArticelMainId",
                table: "Files");
        }
    }
}
