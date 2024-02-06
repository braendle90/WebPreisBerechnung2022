using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class AddInventoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryArticle",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Article = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Catalog = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Article);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryArticle",
                table: "Products",
                column: "InventoryArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventory_InventoryArticle",
                table: "Products",
                column: "InventoryArticle",
                principalTable: "Inventory",
                principalColumn: "Article");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventory_InventoryArticle",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryArticle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryArticle",
                table: "Products");
        }
    }
}
