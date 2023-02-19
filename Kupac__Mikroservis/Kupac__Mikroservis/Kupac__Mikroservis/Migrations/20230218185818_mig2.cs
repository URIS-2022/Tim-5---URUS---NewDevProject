using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kupac__Mikroservis.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdresaVOs",
                columns: table => new
                {
                    AdresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresaVOs", x => x.AdresaID);
                });

            migrationBuilder.CreateTable(
                name: "OvlasceniLices",
                columns: table => new
                {
                    OvlascenoLiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG_BrojPasosa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drazava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTabele = table.Column<int>(type: "int", nullable: false),
                    AdresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlasceniLices", x => x.OvlascenoLiceID);
                    table.ForeignKey(
                        name: "FK_OvlasceniLices_AdresaVOs_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "AdresaVOs",
                        principalColumn: "AdresaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupacs",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prioritet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OstvarenaPovrsina = table.Column<int>(type: "int", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzinaTrajanjaZabraneUGodinama = table.Column<int>(type: "int", nullable: false),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OvlascenoLiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupacs", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupacs_OvlasceniLices_OvlascenoLiceID",
                        column: x => x.OvlascenoLiceID,
                        principalTable: "OvlasceniLices",
                        principalColumn: "OvlascenoLiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplatas",
                columns: table => new
                {
                    UplataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PozivNaBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iznos = table.Column<double>(type: "float", nullable: false),
                    Uplatilac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SvrhaUplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplatas", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK_Uplatas_Kupacs_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupacs",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupacs_OvlascenoLiceID",
                table: "Kupacs",
                column: "OvlascenoLiceID");

            migrationBuilder.CreateIndex(
                name: "IX_OvlasceniLices_AdresaID",
                table: "OvlasceniLices",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplatas_KupacID",
                table: "Uplatas",
                column: "KupacID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uplatas");

            migrationBuilder.DropTable(
                name: "Kupacs");

            migrationBuilder.DropTable(
                name: "OvlasceniLices");

            migrationBuilder.DropTable(
                name: "AdresaVOs");
        }
    }
}
