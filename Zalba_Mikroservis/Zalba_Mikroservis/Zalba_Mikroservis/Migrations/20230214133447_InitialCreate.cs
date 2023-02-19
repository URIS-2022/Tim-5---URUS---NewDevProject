using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zalba_Mikroservis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KupacVOs",
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
                    KupacVOKupacID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupacVOs", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_KupacVOs_KupacVOs_KupacVOKupacID",
                        column: x => x.KupacVOKupacID,
                        principalTable: "KupacVOs",
                        principalColumn: "KupacID");
                });

            migrationBuilder.CreateTable(
                name: "Zalbas",
                columns: table => new
                {
                    ZalbaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPodnosenjaZalbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PodnosilacZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazlogZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumResenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojResenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojOdluka_BrojNadmetanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadnjaNaOsnovuZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalbas", x => x.ZalbaID);
                    table.ForeignKey(
                        name: "FK_Zalbas_KupacVOs_KupacID",
                        column: x => x.KupacID,
                        principalTable: "KupacVOs",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KupacVOs_KupacVOKupacID",
                table: "KupacVOs",
                column: "KupacVOKupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbas_KupacID",
                table: "Zalbas",
                column: "KupacID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zalbas");

            migrationBuilder.DropTable(
                name: "KupacVOs");
        }
    }
}
