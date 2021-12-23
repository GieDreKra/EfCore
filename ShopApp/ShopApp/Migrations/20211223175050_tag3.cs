using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class tag3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ShopItemTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 50, 49, 233, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 19, 50, 49, 238, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 50, 49, 238, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 19, 50, 49, 238, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 50, 49, 238, DateTimeKind.Local).AddTicks(8809));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ShopItemTags");

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 47, 30, 540, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 19, 47, 30, 545, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 47, 30, 545, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 19, 47, 30, 545, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 19, 47, 30, 545, DateTimeKind.Local).AddTicks(2231));
        }
    }
}
