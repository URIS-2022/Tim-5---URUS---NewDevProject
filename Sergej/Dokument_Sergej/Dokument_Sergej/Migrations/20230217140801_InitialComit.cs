using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dokument_Sergej.Migrations
{
    /// <inheritdoc />
    public partial class InitialComit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZavodniBroj = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDonosenjaOdluke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    LicnostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciSistema",
                columns: table => new
                {
                    KorisnikSistemaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciSistema", x => x.KorisnikSistemaID);
                });

            migrationBuilder.CreateTable(
                name: "Licnosti",
                columns: table => new
                {
                    LicnostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licnosti", x => x.LicnostID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumenti");

            migrationBuilder.DropTable(
                name: "KorisniciSistema");

            migrationBuilder.DropTable(
                name: "Licnosti");
        }
    }
}
