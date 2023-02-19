using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NadmetanjeApp.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nadmetanja",
                columns: table => new
                {
                    NadmetanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Krug = table.Column<int>(type: "int", nullable: false),
                    CenaPoHektaru = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nadmetanja", x => x.NadmetanjeID);
                });

            migrationBuilder.CreateTable(
                name: "OtvaranjePonuda",
                columns: table => new
                {
                    OtvaranjePonudeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NadmetanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtvaranjePonuda", x => x.OtvaranjePonudeID);
                    table.ForeignKey(
                        name: "FK_OtvaranjePonuda_Nadmetanja_NadmetanjeID",
                        column: x => x.NadmetanjeID,
                        principalTable: "Nadmetanja",
                        principalColumn: "NadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtvaranjePonuda_NadmetanjeID",
                table: "OtvaranjePonuda",
                column: "NadmetanjeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtvaranjePonuda");

            migrationBuilder.DropTable(
                name: "Nadmetanja");
        }
    }
}
