using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija_Project.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DokumentVOs",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZavodniBroj = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDonosenjaDokumenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentVOs", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanjeVOs",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeKraja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    IzlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    PeriodZakupa = table.Column<int>(type: "int", nullable: false),
                    BrojUcesnika = table.Column<int>(type: "int", nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanjeVOs", x => x.JavnoNadmetanjeID);
                });

            migrationBuilder.CreateTable(
                name: "Licitacijas",
                columns: table => new
                {
                    LicitacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ogranicenje = table.Column<int>(type: "int", nullable: false),
                    KorakCene = table.Column<int>(type: "int", nullable: false),
                    ListaDokumentacijeFizickaLica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListaDokumentacijePravnaLica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokZaDostavljanjePrijava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JavnoNadmetanjeID = table.Column<int>(type: "int", nullable: false),
                    javnoNadmetanjeVOJavnoNadmetanjeID = table.Column<int>(type: "int", nullable: false),
                    DokumentID = table.Column<int>(type: "int", nullable: false),
                    dokumentVODokumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacijas", x => x.LicitacijaID);
                    table.ForeignKey(
                        name: "FK_Licitacijas_DokumentVOs_dokumentVODokumentID",
                        column: x => x.dokumentVODokumentID,
                        principalTable: "DokumentVOs",
                        principalColumn: "DokumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licitacijas_JavnoNadmetanjeVOs_javnoNadmetanjeVOJavnoNadmetanjeID",
                        column: x => x.javnoNadmetanjeVOJavnoNadmetanjeID,
                        principalTable: "JavnoNadmetanjeVOs",
                        principalColumn: "JavnoNadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licitacijas_dokumentVODokumentID",
                table: "Licitacijas",
                column: "dokumentVODokumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Licitacijas_javnoNadmetanjeVOJavnoNadmetanjeID",
                table: "Licitacijas",
                column: "javnoNadmetanjeVOJavnoNadmetanjeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licitacijas");

            migrationBuilder.DropTable(
                name: "DokumentVOs");

            migrationBuilder.DropTable(
                name: "JavnoNadmetanjeVOs");
        }
    }
}
