using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class add_File_Model1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Logos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logos_FileId",
                table: "Logos",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logos_Files_FileId",
                table: "Logos",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logos_Files_FileId",
                table: "Logos");

            migrationBuilder.DropIndex(
                name: "IX_Logos_FileId",
                table: "Logos");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Logos");
        }
    }
}
