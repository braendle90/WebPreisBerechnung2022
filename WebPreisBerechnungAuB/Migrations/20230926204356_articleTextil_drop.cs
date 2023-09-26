using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class articleTextil_drop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTextils",
                table: "ArticleTextils");

            migrationBuilder.RenameTable(
                name: "ArticleTextils",
                newName: "ArticleTextil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTextil",
                table: "ArticleTextil",
                column: "ArticleNr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTextil",
                table: "ArticleTextil");

            migrationBuilder.RenameTable(
                name: "ArticleTextil",
                newName: "ArticleTextils");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTextils",
                table: "ArticleTextils",
                column: "ArticleNr");
        }
    }
}
