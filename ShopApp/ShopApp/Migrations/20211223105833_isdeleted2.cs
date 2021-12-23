using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class isdeleted2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 12, 58, 32, 335, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 12, 58, 32, 340, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 12, 58, 32, 340, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 12, 58, 32, 340, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 12, 58, 32, 340, DateTimeKind.Local).AddTicks(2969));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 12, 47, 57, 341, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 12, 47, 57, 347, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 12, 47, 57, 347, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2022, 4, 2, 12, 47, 57, 347, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "ShopsItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2022, 1, 2, 12, 47, 57, 347, DateTimeKind.Local).AddTicks(4201));
        }
    }
}
