using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopsItems_Shops_ShopId",
                table: "ShopsItems");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "ShopsItems",
                newName: "ShopId1");

            migrationBuilder.RenameIndex(
                name: "IX_ShopsItems_ShopId",
                table: "ShopsItems",
                newName: "IX_ShopsItems_ShopId1");

            migrationBuilder.InsertData(
                table: "ShopsItems",
                columns: new[] { "Id", "ExpiryDate", "Name", "ShopId1" },
                values: new object[] { 1, new DateTime(2022, 3, 26, 18, 24, 31, 615, DateTimeKind.Local).AddTicks(2540), "ShopItem1", null });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopsItems_Shops_ShopId1",
                table: "ShopsItems",
                column: "ShopId1",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopsItems_Shops_ShopId1",
                table: "ShopsItems");

            migrationBuilder.DeleteData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ShopId1",
                table: "ShopsItems",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopsItems_ShopId1",
                table: "ShopsItems",
                newName: "IX_ShopsItems_ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopsItems_Shops_ShopId",
                table: "ShopsItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
