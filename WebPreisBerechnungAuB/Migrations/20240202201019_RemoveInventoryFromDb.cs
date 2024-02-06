using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class RemoveInventoryFromDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventory_Inventoryarticle",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Products_Inventoryarticle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventoryarticle",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Inventoryarticle",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    article = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.article);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Inventoryarticle",
                table: "Products",
                column: "Inventoryarticle");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventory_Inventoryarticle",
                table: "Products",
                column: "Inventoryarticle",
                principalTable: "Inventory",
                principalColumn: "article");
        }
    }
}
