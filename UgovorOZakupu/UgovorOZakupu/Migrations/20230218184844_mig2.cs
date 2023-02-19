using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UgovorOZakupu.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumenta",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDonosenjaDokumenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenta", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "JavnaNadmetanja",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeKraja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    IzlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    BrojUcesnika = table.Column<int>(type: "int", nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnaNadmetanja", x => x.JavnoNadmetanjeID);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
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
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacID);
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

            migrationBuilder.CreateTable(
                name: "Ugovori",
                columns: table => new
                {
                    UgovorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odluka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipGarancije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokoviDospeca = table.Column<int>(type: "int", nullable: false),
                    ZavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumZavodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ministar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokZaVracanjeZemljista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MestoPotpisivanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPotpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    javnoNadmetanjeID = table.Column<int>(type: "int", nullable: false),
                    dokumentID = table.Column<int>(type: "int", nullable: false),
                    kupacID = table.Column<int>(type: "int", nullable: false),
                    licnostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovori", x => x.UgovorID);
                    table.ForeignKey(
                        name: "FK_Ugovori_Dokumenta_dokumentID",
                        column: x => x.dokumentID,
                        principalTable: "Dokumenta",
                        principalColumn: "DokumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ugovori_JavnaNadmetanja_javnoNadmetanjeID",
                        column: x => x.javnoNadmetanjeID,
                        principalTable: "JavnaNadmetanja",
                        principalColumn: "JavnoNadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ugovori_Kupci_kupacID",
                        column: x => x.kupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ugovori_Licnosti_licnostID",
                        column: x => x.licnostID,
                        principalTable: "Licnosti",
                        principalColumn: "LicnostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dokumenta",
                columns: new[] { "DokumentID", "Datum", "DatumDonosenjaDokumenta", "Sablon", "ZavodniBroj" },
                values: new object[,]
                {
                    { 5, new DateTime(2009, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2011, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki sablonnnnn", "123Aa" },
                    { 7, new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki sablonnnnnn", "123aA" }
                });

            migrationBuilder.InsertData(
                table: "JavnaNadmetanja",
                columns: new[] { "JavnoNadmetanjeID", "BrojUcesnika", "IzlicitiranaCena", "Izuzeto", "Status", "Tip", "VisinaDopuneDepozita", "VremeKraja" },
                values: new object[,]
                {
                    { 6, 26, 150000, false, "neki status", "neki tip", 1350, "13.35h" },
                    { 66, 26, 150000, false, "neki status", "neki tip", 1350, "13.35h" }
                });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "KupacID", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DuzinaTrajanjaZabraneUGodinama", "ImaZabranu", "Lice", "OstvarenaPovrsina", "Prioritet" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "nije ovlasceno", 1505005, "nema" },
                    { 666, new DateTime(2014, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, true, "nije ovlasceno", 1505005, "nema" }
                });

            migrationBuilder.InsertData(
                table: "Licnosti",
                columns: new[] { "LicnostID", "Funkcija", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 6, "ucesnik", "Masa", "Bobar" },
                    { 65, "ucesnik", "Ema", "Kuzmanovic" }
                });

            migrationBuilder.InsertData(
                table: "Ugovori",
                columns: new[] { "UgovorID", "DatumPotpisa", "DatumZavodjenja", "Lice", "MestoPotpisivanja", "Ministar", "Odluka", "RokZaVracanjeZemljista", "RokoviDospeca", "TipGarancije", "ZavodniBroj", "dokumentID", "javnoNadmetanjeID", "kupacID", "licnostID" },
                values: new object[] { 1, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko lice", "Beograd", "ekonomije", "nije donesena nikakva konacna odluka", new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "godisnja", "123a", 7, 6, 666, 65 });

            migrationBuilder.InsertData(
                table: "Ugovori",
                columns: new[] { "UgovorID", "DatumPotpisa", "DatumZavodjenja", "Lice", "MestoPotpisivanja", "Ministar", "Odluka", "RokZaVracanjeZemljista", "RokoviDospeca", "TipGarancije", "ZavodniBroj", "dokumentID", "javnoNadmetanjeID", "kupacID", "licnostID" },
                values: new object[] { 2, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko lice", "Beograd", "ekonomije", "nije donesena nikakva konacna odluka", new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "godisnja", "123a", 7, 6, 666, 65 });

            migrationBuilder.CreateIndex(
                name: "IX_Ugovori_dokumentID",
                table: "Ugovori",
                column: "dokumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovori_javnoNadmetanjeID",
                table: "Ugovori",
                column: "javnoNadmetanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovori_kupacID",
                table: "Ugovori",
                column: "kupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovori_licnostID",
                table: "Ugovori",
                column: "licnostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ugovori");

            migrationBuilder.DropTable(
                name: "Dokumenta");

            migrationBuilder.DropTable(
                name: "JavnaNadmetanja");

            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "Licnosti");
        }
    }
}
