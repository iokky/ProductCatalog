using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductCatalog.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Product = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_group_product_category_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "product_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ProductGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ecom = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_page_product_group_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "product_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "product_category",
                columns: new[] { "Id", "Product" },
                values: new object[,]
                {
                    { 1, "ECOM" },
                    { 2, "VPN" }
                });

            migrationBuilder.InsertData(
                table: "product_group",
                columns: new[] { "Id", "Name", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1, "Корзина", 1 },
                    { 2, "VPN", 2 },
                    { 3, "Разводная виртуальной инфраструктуры", 2 }
                });

            migrationBuilder.InsertData(
                table: "product_page",
                columns: new[] { "Id", "ContentType", "Ecom", "ProductGroupId", "Url" },
                values: new object[,]
                {
                    { 1, "sale", "yes", 1, "/shop/cart" },
                    { 2, "sale", "yes", 2, "/products/gost-vpn_1" },
                    { 3, "sale", "yes", 2, "/shop/products/kanal-svyazi-l2-vpn" },
                    { 4, "sale", "yes", 3, "/services/setevaya-infrastruktura" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_group_ProductCategoryId",
                table: "product_group",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_page_ProductGroupId",
                table: "product_page",
                column: "ProductGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_page");

            migrationBuilder.DropTable(
                name: "product_group");

            migrationBuilder.DropTable(
                name: "product_category");
        }
    }
}
