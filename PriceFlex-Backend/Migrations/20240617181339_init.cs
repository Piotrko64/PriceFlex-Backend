using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceFlex_Backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnlineShopScrappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Classes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineShopScrappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineShopScrappers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScrapperPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<float>(type: "float", nullable: false),
                    OnlineShopScrapperId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapperPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrapperPrices_OnlineShopScrappers_OnlineShopScrapperId",
                        column: x => x.OnlineShopScrapperId,
                        principalTable: "OnlineShopScrappers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrapperPrices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "OnlineShopScrappers",
                columns: new[] { "Id", "Classes", "CreatedAt", "Name", "UpdatedAt", "Url", "UserId" },
                values: new object[,]
                {
                    { 8, ".main-price .whole", new DateTime(2024, 6, 17, 18, 13, 38, 770, DateTimeKind.Utc).AddTicks(282), "Vinted", new DateTime(2024, 6, 17, 18, 13, 38, 770, DateTimeKind.Utc).AddTicks(282), "https://www.mediaexpert.pl/komputery-i-tablety/laptopy-i-ultrabooki/laptopy/laptop-lenovo-ideapad-gaming-3-15ach6-15-6-ips-144hz-r5-5500h-16gb-ram-512gb-ssd-geforce-rtx2050-windows-11-home", null },
                    { 55, ".main-price .whole", new DateTime(2024, 6, 17, 18, 13, 38, 770, DateTimeKind.Utc).AddTicks(276), "Media Expert", new DateTime(2024, 6, 17, 18, 13, 38, 770, DateTimeKind.Utc).AddTicks(279), "https://www.mediaexpert.pl/komputery-i-tablety/laptopy-i-ultrabooki/laptopy/laptop-lenovo-ideapad-gaming-3-15ach6-15-6-ips-144hz-r5-5500h-16gb-ram-512gb-ssd-geforce-rtx2050-windows-11-home", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineShopScrappers_UserId",
                table: "OnlineShopScrappers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapperPrices_OnlineShopScrapperId",
                table: "ScrapperPrices",
                column: "OnlineShopScrapperId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapperPrices_UserId",
                table: "ScrapperPrices",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrapperPrices");

            migrationBuilder.DropTable(
                name: "OnlineShopScrappers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
