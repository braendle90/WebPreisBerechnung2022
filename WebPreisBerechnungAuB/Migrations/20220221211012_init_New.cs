using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebPreisBerechnungAuB.Migrations
{
    public partial class init_New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationPrice = table.Column<double>(type: "float", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PiecesFrom = table.Column<int>(type: "int", nullable: false),
                    PiecesTo = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfColors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChargeTyp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isOneTimeCharge = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraCharge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogoExtraCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogoExtraCharge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeSurfaceSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceSizeFrom = table.Column<double>(type: "float", nullable: false),
                    SurfaceSizeTo = table.Column<double>(type: "float", nullable: false),
                    RangeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeSurfaceSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeFrom = table.Column<int>(type: "int", nullable: false),
                    RangeTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextilColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextilColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPriceHigher = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextilColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Textils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextilName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Textils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurfaceWidht = table.Column<double>(type: "float", nullable: false),
                    SurfaceHight = table.Column<double>(type: "float", nullable: false),
                    LogoSurfaceSize = table.Column<double>(type: "float", nullable: false),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    isOld = table.Column<bool>(type: "bit", nullable: false),
                    LogoPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerScreen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceScreenPrint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceTransfer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransferLogoPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isLogoStorage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logos_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPieces = table.Column<int>(type: "int", nullable: false),
                    isOrdered = table.Column<bool>(type: "bit", nullable: false),
                    TextilId = table.Column<int>(type: "int", nullable: true),
                    TextilColorId = table.Column<int>(type: "int", nullable: true),
                    PriceTransfer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceScreenPrint = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_TextilColors_TextilColorId",
                        column: x => x.TextilColorId,
                        principalTable: "TextilColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Textils_TextilId",
                        column: x => x.TextilId,
                        principalTable: "Textils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TexilId = table.Column<int>(type: "int", nullable: true),
                    NumberColorsId = table.Column<int>(type: "int", nullable: true),
                    RangeId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTable_Colors_NumberColorsId",
                        column: x => x.NumberColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTable_RangeTable_RangeId",
                        column: x => x.RangeId,
                        principalTable: "RangeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTable_Textils_TexilId",
                        column: x => x.TexilId,
                        principalTable: "Textils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceTableTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TexilId = table.Column<int>(type: "int", nullable: true),
                    RangeLogoId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTableTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTableTransfer_RangeSurfaceSizes_RangeLogoId",
                        column: x => x.RangeLogoId,
                        principalTable: "RangeSurfaceSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTableTransfer_Textils_TexilId",
                        column: x => x.TexilId,
                        principalTable: "Textils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPositionLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositionLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPositionLogos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPositionLogos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    LogoId = table.Column<int>(type: "int", nullable: true),
                    OrderPositionLogoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionLogos_Logos_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Logos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionLogos_OrderPositionLogos_OrderPositionLogoId",
                        column: x => x.OrderPositionLogoId,
                        principalTable: "OrderPositionLogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionLogos_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraChargeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraChargeId = table.Column<int>(type: "int", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoId = table.Column<int>(type: "int", nullable: true),
                    idForToggle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionLogoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraChargeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraChargeList_ExtraCharge_ExtraChargeId",
                        column: x => x.ExtraChargeId,
                        principalTable: "ExtraCharge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraChargeList_Logos_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Logos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraChargeList_PositionLogos_PositionLogoId",
                        column: x => x.PositionLogoId,
                        principalTable: "PositionLogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraChargeList_ExtraChargeId",
                table: "ExtraChargeList",
                column: "ExtraChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraChargeList_LogoId",
                table: "ExtraChargeList",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraChargeList_PositionLogoId",
                table: "ExtraChargeList",
                column: "PositionLogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Logos_ColorId",
                table: "Logos",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Logos_UserId",
                table: "Logos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositionLogos_OrderId",
                table: "OrderPositionLogos",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositionLogos_UserId",
                table: "OrderPositionLogos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TextilColorId",
                table: "Orders",
                column: "TextilColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TextilId",
                table: "Orders",
                column: "TextilId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLogos_LogoId",
                table: "PositionLogos",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLogos_OrderPositionLogoId",
                table: "PositionLogos",
                column: "OrderPositionLogoId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLogos_PositionId",
                table: "PositionLogos",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_NumberColorsId",
                table: "PriceTable",
                column: "NumberColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_RangeId",
                table: "PriceTable",
                column: "RangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_TexilId",
                table: "PriceTable",
                column: "TexilId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTableTransfer_RangeLogoId",
                table: "PriceTableTransfer",
                column: "RangeLogoId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTableTransfer_TexilId",
                table: "PriceTableTransfer",
                column: "TexilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationTransfer");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExtraChargeList");

            migrationBuilder.DropTable(
                name: "LogoExtraCharge");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "PriceTable");

            migrationBuilder.DropTable(
                name: "PriceTableTransfer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExtraCharge");

            migrationBuilder.DropTable(
                name: "PositionLogos");

            migrationBuilder.DropTable(
                name: "RangeTable");

            migrationBuilder.DropTable(
                name: "RangeSurfaceSizes");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "OrderPositionLogos");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TextilColors");

            migrationBuilder.DropTable(
                name: "Textils");
        }
    }
}
