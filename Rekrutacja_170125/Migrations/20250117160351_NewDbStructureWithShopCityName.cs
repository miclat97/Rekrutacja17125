using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rekrutacja_170125.Migrations
{
    /// <inheritdoc />
    public partial class NewDbStructureWithShopCityName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "City 1", "11111", "Street 1" },
                    { 2, "City 2", "22222", "Street 2" },
                    { 3, "City 3", "33333", "Street 3" },
                    { 4, "City 4", "44444", "Street 4" },
                    { 5, "City 5", "55555", "Street 5" },
                    { 6, "City 6", "66666", "Street 6" },
                    { 7, "City 7", "77777", "Street 7" },
                    { 8, "City 8", "88888", "Street 8" },
                    { 9, "City 9", "99999", "Street 9" },
                    { 10, "City 10", "10101", "Street 10" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "GrossPrice", "Name", "NetPrice" },
                values: new object[,]
                {
                    { 1, 123.0m, "P001", 100.0m },
                    { 2, 246.0m, "P002", 200.0m },
                    { 3, 184.5m, "P003", 150.0m },
                    { 4, 221.4m, "P004", 180.0m },
                    { 5, 307.5m, "P005", 250.0m },
                    { 6, 147.6m, "P006", 120.0m },
                    { 7, 98.4m, "P007", 80.0m },
                    { 8, 233.7m, "P008", 190.0m },
                    { 9, 270.6m, "P009", 220.0m },
                    { 10, 159.9m, "P010", 130.0m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "City 1", "Sklep 1" },
                    { 2, "City 2", "Sklep 2" },
                    { 3, "Cityw 3", "Sklep 3" },
                    { 4, "City 4", "Sklep 4" },
                    { 5, "Cityw 5", "Sklep 5" },
                    { 6, "Cityw 6", "Sklep 6" },
                    { 7, "City 7", "Sklep 7" },
                    { 8, "Cityw 8", "Sklep 8" },
                    { 9, "City 9", "Sklep 9" },
                    { 10, "City 10", "Sklep 10" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientId", "PaymentMethod", "ShopId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 3, 2, 3 },
                    { 4, 4, 0, 4 },
                    { 5, 5, 1, 5 },
                    { 6, 6, 2, 6 },
                    { 7, 7, 0, 7 },
                    { 8, 8, 1, 8 },
                    { 9, 9, 2, 9 },
                    { 10, 10, 0, 10 }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 },
                    { 3, 10, 5 },
                    { 4, 5, 1 },
                    { 5, 3, 2 },
                    { 6, 4, 5 },
                    { 7, 3, 3 },
                    { 8, 2, 5 },
                    { 9, 3, 4 },
                    { 10, 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopId",
                table: "Orders",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
