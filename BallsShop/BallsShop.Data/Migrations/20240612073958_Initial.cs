using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BallsShop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Balls",
                columns: table => new
                {
                    BallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    Shop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balls", x => x.BallId);
                    table.ForeignKey(
                        name: "FK_Balls_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    BallId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Balls_BallId",
                        column: x => x.BallId,
                        principalTable: "Balls",
                        principalColumn: "BallId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Football" },
                    { 2, "Basketball" },
                    { 3, "Volleyball" },
                    { 4, "Tennis" },
                    { 5, "American Football" }
                });

            migrationBuilder.InsertData(
                table: "Balls",
                columns: new[] { "BallId", "CategoryId", "ImageUrl", "Perimeter", "Price", "Shop" },
                values: new object[,]
                {
                    { 1, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6W79cKqoFwkReD5n8FwZM_99dvUU4OGAoQQ&s", 68.799999999999997, 106.99m, "Sofia" },
                    { 2, 3, "https://shop.basketballengland.co.uk/cdn/shop/products/WilsonBasketballEnglandEVONXTOfficialGameBall1_1024x1024.png?v=1631103919", 75.0, 149.99m, "Varna" },
                    { 3, 2, "https://i.ebayimg.com/images/g/WLAAAOSw-4BkfsOn/s-l1600.webp", 66.0, 107.4m, "Plovdiv" },
                    { 4, 5, "https://m.media-amazon.com/images/I/71jGnieoAZL._AC_SX679_.jpg", 71.0, 101.99m, "Sofia" },
                    { 5, 4, "https://i0.wp.com/keysports.org/wp-content/uploads/2017/11/product_14.png?fit=1200%2C1200&ssl=1", 21.0, 20.76m, "Sofia" },
                    { 6, 1, "https://m.media-amazon.com/images/I/51Xvsr0a4OL.jpg", 68.799999999999997, 106.99m, "Sofia" },
                    { 7, 1, "https://thirdcoastsoccer.net/cdn/shop/files/Picture3-678.jpg?v=1707155573&width=1800", 68.799999999999997, 174.99m, "Sofia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balls_CategoryId",
                table: "Balls",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BallId",
                table: "CartItems",
                column: "BallId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Balls");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
