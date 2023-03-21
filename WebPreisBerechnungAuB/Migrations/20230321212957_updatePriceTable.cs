using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class updatePriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceUpdatePercent",
                table: "PriceTable",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceUpdatePercent",
                table: "PriceTable");
        }
    }
}
