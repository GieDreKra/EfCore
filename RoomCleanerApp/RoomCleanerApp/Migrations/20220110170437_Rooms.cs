using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomCleanerApp.Migrations
{
    public partial class Rooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Romms_Hotels_HotelId",
                table: "Romms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Romms",
                table: "Romms");

            migrationBuilder.RenameTable(
                name: "Romms",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Romms_HotelId",
                table: "Rooms",
                newName: "IX_Rooms_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Romms");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelId",
                table: "Romms",
                newName: "IX_Romms_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Romms",
                table: "Romms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Romms_Hotels_HotelId",
                table: "Romms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
