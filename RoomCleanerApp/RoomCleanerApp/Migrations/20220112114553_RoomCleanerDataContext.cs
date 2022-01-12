using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomCleanerApp.Migrations
{
    public partial class RoomCleanerDataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomCleaner_Cleaners_CleanerId",
                table: "RoomCleaner");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomCleaner_Rooms_RoomId",
                table: "RoomCleaner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomCleaner",
                table: "RoomCleaner");

            migrationBuilder.RenameTable(
                name: "RoomCleaner",
                newName: "RoomsCleaners");

            migrationBuilder.RenameIndex(
                name: "IX_RoomCleaner_RoomId",
                table: "RoomsCleaners",
                newName: "IX_RoomsCleaners_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomCleaner_CleanerId",
                table: "RoomsCleaners",
                newName: "IX_RoomsCleaners_CleanerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsCleaners",
                table: "RoomsCleaners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsCleaners_Cleaners_CleanerId",
                table: "RoomsCleaners",
                column: "CleanerId",
                principalTable: "Cleaners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsCleaners_Rooms_RoomId",
                table: "RoomsCleaners",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsCleaners_Cleaners_CleanerId",
                table: "RoomsCleaners");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsCleaners_Rooms_RoomId",
                table: "RoomsCleaners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsCleaners",
                table: "RoomsCleaners");

            migrationBuilder.RenameTable(
                name: "RoomsCleaners",
                newName: "RoomCleaner");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsCleaners_RoomId",
                table: "RoomCleaner",
                newName: "IX_RoomCleaner_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsCleaners_CleanerId",
                table: "RoomCleaner",
                newName: "IX_RoomCleaner_CleanerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomCleaner",
                table: "RoomCleaner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCleaner_Cleaners_CleanerId",
                table: "RoomCleaner",
                column: "CleanerId",
                principalTable: "Cleaners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCleaner_Rooms_RoomId",
                table: "RoomCleaner",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
