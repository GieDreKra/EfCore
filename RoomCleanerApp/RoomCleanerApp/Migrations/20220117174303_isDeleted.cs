using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomCleanerApp.Migrations
{
    public partial class isDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "RoomsCleaners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Cleaners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "RoomsCleaners");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Cities");
        }
    }
}
