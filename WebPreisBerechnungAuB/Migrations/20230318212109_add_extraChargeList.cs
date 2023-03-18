﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class add_extraChargeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargePieces",
                table: "ExtraCharge");

            migrationBuilder.DropColumn(
                name: "ChargePriceTotal",
                table: "ExtraCharge");

            migrationBuilder.AddColumn<int>(
                name: "ChargePieces",
                table: "ExtraChargeList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ChargePriceTotal",
                table: "ExtraChargeList",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargePieces",
                table: "ExtraChargeList");

            migrationBuilder.DropColumn(
                name: "ChargePriceTotal",
                table: "ExtraChargeList");

            migrationBuilder.AddColumn<int>(
                name: "ChargePieces",
                table: "ExtraCharge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ChargePriceTotal",
                table: "ExtraCharge",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
