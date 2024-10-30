using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityPharmacyChain.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pharmacy",
                columns: table => new
                {
                    pharmacy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pharmacy_number = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<long>(type: "bigint", nullable: true),
                    address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    director_full_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy", x => x.pharmacy_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_code = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_group = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pharmaceutical_group",
                columns: table => new
                {
                    pharmaceutical_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmaceutical_group", x => x.pharmaceutical_group_id);
                    table.ForeignKey(
                        name: "FK_pharmaceutical_group_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PharmacyProducts",
                columns: table => new
                {
                    pharmacy_product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    pharmacy_id = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyProducts", x => x.pharmacy_product_id);
                    table.ForeignKey(
                        name: "FK_PharmacyProducts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyProducts_pharmacy_pharmacy_id",
                        column: x => x.pharmacy_id,
                        principalTable: "pharmacy",
                        principalColumn: "pharmacy_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "price_list",
                columns: table => new
                {
                    price_list_entry_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    pharmacy_id = table.Column<int>(type: "int", nullable: false),
                    sold_count = table.Column<int>(type: "int", nullable: true),
                    manufacturer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payment_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sale_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_list", x => x.price_list_entry_id);
                    table.ForeignKey(
                        name: "FK_price_list_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_price_list_pharmacy_pharmacy_id",
                        column: x => x.pharmacy_id,
                        principalTable: "pharmacy",
                        principalColumn: "pharmacy_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_pharmaceutical_group_product_id",
                table: "pharmaceutical_group",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProducts_pharmacy_id",
                table: "PharmacyProducts",
                column: "pharmacy_id");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProducts_product_id",
                table: "PharmacyProducts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_price_list_pharmacy_id",
                table: "price_list",
                column: "pharmacy_id");

            migrationBuilder.CreateIndex(
                name: "IX_price_list_product_id",
                table: "price_list",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pharmaceutical_group");

            migrationBuilder.DropTable(
                name: "PharmacyProducts");

            migrationBuilder.DropTable(
                name: "price_list");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "pharmacy");
        }
    }
}
