using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationItemsApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedValueId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationItems_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationItemId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Values_RegistrationItems_RegistrationItemId",
                        column: x => x.RegistrationItemId,
                        principalTable: "RegistrationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Form1" },
                    { 2, "Form2" }
                });

            migrationBuilder.InsertData(
                table: "RegistrationItems",
                columns: new[] { "Id", "FormId", "Name", "SelectedValueId" },
                values: new object[,]
                {
                    { 1, null, "Reikia atlikti rangos darbus", 1 },
                    { 2, null, "Rangos darbus atliks", 1 },
                    { 3, null, "Verslo klientas", 1 },
                    { 4, null, "Skaičiavimo metodas", 1 },
                    { 5, null, "Svarbus klientas", 1 }
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Name", "RegistrationItemId" },
                values: new object[,]
                {
                    { 13, "Rankinis", null },
                    { 12, "Automatinis", null },
                    { 11, "Ne", null },
                    { 10, "Taip", null },
                    { 9, "Mėnesinis rangovas", null },
                    { 8, "Metinis rangovas", null },
                    { 4, " ", null },
                    { 6, "Taip", null },
                    { 5, " ", null },
                    { 14, "Taip", null },
                    { 3, " ", null },
                    { 2, " ", null },
                    { 1, " ", null },
                    { 7, "Ne", null },
                    { 15, "Ne", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationItems_FormId",
                table: "RegistrationItems",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Values_RegistrationItemId",
                table: "Values",
                column: "RegistrationItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "RegistrationItems");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
