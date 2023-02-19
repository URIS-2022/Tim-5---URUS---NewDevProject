using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicnostProjekat.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresas",
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
                    table.PrimaryKey("PK_Adresas", x => x.AdresaID);
                });

            migrationBuilder.CreateTable(
                name: "KontaktOsobas",
                columns: table => new
                {
                    KontaktOsobaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktOsobas", x => x.KontaktOsobaID);
                });

            migrationBuilder.CreateTable(
                name: "Kupcis",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prioritet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OstvarenaPovrsina = table.Column<int>(type: "int", nullable: false),
                    Uplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzinaTrajanjaZabraneUGodinama = table.Column<int>(type: "int", nullable: false),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupcis", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "PravnaLicas",
                columns: table => new
                {
                    PravnoLiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaID = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PravnaLicas", x => x.PravnoLiceID);
                });

            migrationBuilder.CreateTable(
                name: "Licnostis",
                columns: table => new
                {
                    LicnostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licnostis", x => x.LicnostID);
                    table.ForeignKey(
                        name: "FK_Licnostis_Kupcis_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupcis",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FizickaLicas",
                columns: table => new
                {
                    FizickoLiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaID = table.Column<int>(type: "int", nullable: false),
                    KontaktOsobaID = table.Column<int>(type: "int", nullable: false),
                    LicnostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickaLicas", x => x.FizickoLiceID);
                    table.ForeignKey(
                        name: "FK_FizickaLicas_Adresas_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adresas",
                        principalColumn: "AdresaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FizickaLicas_KontaktOsobas_KontaktOsobaID",
                        column: x => x.KontaktOsobaID,
                        principalTable: "KontaktOsobas",
                        principalColumn: "KontaktOsobaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FizickaLicas_Licnostis_LicnostID",
                        column: x => x.LicnostID,
                        principalTable: "Licnostis",
                        principalColumn: "LicnostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FizickaLicas_AdresaID",
                table: "FizickaLicas",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "IX_FizickaLicas_KontaktOsobaID",
                table: "FizickaLicas",
                column: "KontaktOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_FizickaLicas_LicnostID",
                table: "FizickaLicas",
                column: "LicnostID");

            migrationBuilder.CreateIndex(
                name: "IX_Licnostis_KupacID",
                table: "Licnostis",
                column: "KupacID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizickaLicas");

            migrationBuilder.DropTable(
                name: "PravnaLicas");

            migrationBuilder.DropTable(
                name: "Adresas");

            migrationBuilder.DropTable(
                name: "KontaktOsobas");

            migrationBuilder.DropTable(
                name: "Licnostis");

            migrationBuilder.DropTable(
                name: "Kupcis");
        }
    }
}
