using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BallsShop.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "Balls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c60da481-3bf1-452b-9119-87184184bc87", 0, "6e830d81-e571-435b-8695-e44ce89f04a9", "testSeller@mail.com", false, false, null, "TESTSELLER@MAIL.COM", "TESTSELLER@MAIL.COM", "AQAAAAEAACcQAAAAEIXiiXKpO1BFgsfHimaL0si4VGZoFl5AoF9FRnLQ/zsQ2CJ7KpBQySYjTEEkDAO/fQ==", null, false, "4c754a17-2369-4d7d-b7ee-71ad67fb40bf", false, "testSeller@mail.com" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerId", "Name", "UserId" },
                values: new object[] { new Guid("c60da481-3bf1-452b-9119-87184184bc87"), "TestSeller", "c60da481-3bf1-452b-9119-87184184bc87" });

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 1,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 2,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 3,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 4,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 5,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 6,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.UpdateData(
                table: "Balls",
                keyColumn: "BallId",
                keyValue: 7,
                column: "SellerId",
                value: new Guid("c60da481-3bf1-452b-9119-87184184bc87"));

            migrationBuilder.CreateIndex(
                name: "IX_Balls_SellerId",
                table: "Balls",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balls_Sellers_SellerId",
                table: "Balls",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balls_Sellers_SellerId",
                table: "Balls");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Balls_SellerId",
                table: "Balls");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c60da481-3bf1-452b-9119-87184184bc87");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Balls");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
