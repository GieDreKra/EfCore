using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class data4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 26, 18, 28, 10, 946, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.InsertData(
                table: "ShopsItems",
                columns: new[] { "Id", "ExpiryDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 3, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(902), "ShopItem2", null },
                    { 3, new DateTime(2021, 12, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(947), "ShopItem3", null },
                    { 4, new DateTime(2022, 3, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(954), "ShopItem4", null },
                    { 5, new DateTime(2021, 12, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(959), "ShopItem5", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 3, 26, 18, 25, 40, 247, DateTimeKind.Local).AddTicks(5589));
        }
    }
}
