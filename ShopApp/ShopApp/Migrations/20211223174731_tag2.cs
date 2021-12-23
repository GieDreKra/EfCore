using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class tag2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Tags");

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
        }
    }
}
