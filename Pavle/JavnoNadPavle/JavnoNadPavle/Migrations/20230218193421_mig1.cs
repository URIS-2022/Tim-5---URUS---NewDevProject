using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JavnoNadPavle.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etape",
                columns: table => new
                {
                    EtapaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etape", x => x.EtapaID);
                });

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
                name: "JavnaNadmetanja",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    IzlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    BrojUcesnika = table.Column<int>(type: "int", nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NadmetanjeID = table.Column<int>(type: "int", nullable: false),
                    EtapaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnaNadmetanja", x => x.JavnoNadmetanjeID);
                    table.ForeignKey(
                        name: "FK_JavnaNadmetanja_Etape_EtapaID",
                        column: x => x.EtapaID,
                        principalTable: "Etape",
                        principalColumn: "EtapaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JavnaNadmetanja_Nadmetanja_NadmetanjeID",
                        column: x => x.NadmetanjeID,
                        principalTable: "Nadmetanja",
                        principalColumn: "NadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JavnaNadmetanja_EtapaID",
                table: "JavnaNadmetanja",
                column: "EtapaID");

            migrationBuilder.CreateIndex(
                name: "IX_JavnaNadmetanja_NadmetanjeID",
                table: "JavnaNadmetanja",
                column: "NadmetanjeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavnaNadmetanja");

            migrationBuilder.DropTable(
                name: "Etape");

            migrationBuilder.DropTable(
                name: "Nadmetanja");
        }
    }
}
