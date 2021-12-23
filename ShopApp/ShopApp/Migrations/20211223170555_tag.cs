using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemTags",
                columns: table => new
                {
                    ShopItemId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemTags", x => new { x.TagId, x.ShopItemId });
                    table.ForeignKey(
                        name: "FK_ShopItemTags_ShopsItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopItemTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 5, 54, 133, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemTags_ShopItemId",
                table: "ShopItemTags",
                column: "ShopItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItemTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 13, 0, 3, 118, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 13, 0, 3, 125, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 13, 0, 3, 125, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 13, 0, 3, 125, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 13, 0, 3, 125, DateTimeKind.Local).AddTicks(3593));
        }
    }
}
