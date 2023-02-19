using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcela_MikroservisiProjekat.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deoParcele",
                columns: table => new
                {
                    deoParceleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    povrsina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    redniBroj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deoParcele", x => x.deoParceleId);
                });

            migrationBuilder.CreateTable(
                name: "katastarskaOpstinaVO",
                columns: table => new
                {
                    katastarskaOpstinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    katastarskaOpstinaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_katastarskaOpstinaVO", x => x.katastarskaOpstinaId);
                });

            migrationBuilder.CreateTable(
                name: "parcela",
                columns: table => new
                {
                    parcelaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    povrsina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnikParcele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojParcele = table.Column<int>(type: "int", nullable: false),
                    brojListaNepokretnosti = table.Column<int>(type: "int", nullable: false),
                    kultura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    klasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    obradivost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zasticenaZona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oblikSvojine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odvodnjavanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kulturaStvarsnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    klasaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    obradivostStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zasticenaZonaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odvodnjavanjeStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    katastarskaOpstinaId = table.Column<int>(type: "int", nullable: false),
                    deoParceleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcela", x => x.parcelaId);
                    table.ForeignKey(
                        name: "FK_parcela_deoParcele_deoParceleId",
                        column: x => x.deoParceleId,
                        principalTable: "deoParcele",
                        principalColumn: "deoParceleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parcela_katastarskaOpstinaVO_katastarskaOpstinaId",
                        column: x => x.katastarskaOpstinaId,
                        principalTable: "katastarskaOpstinaVO",
                        principalColumn: "katastarskaOpstinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "deoParcele",
                columns: new[] { "deoParceleId", "povrsina", "redniBroj" },
                values: new object[,]
                {
                    { 1, "200m2", 3 },
                    { 2, "300m2", 4 },
                    { 3, "400m2", 5 }
                });

            migrationBuilder.InsertData(
                table: "katastarskaOpstinaVO",
                columns: new[] { "katastarskaOpstinaId", "katastarskaOpstinaNaziv" },
                values: new object[,]
                {
                    { 1, "Lipovac" },
                    { 2, "Brus" },
                    { 3, "Odzaci" }
                });

            migrationBuilder.InsertData(
                table: "parcela",
                columns: new[] { "parcelaId", "brojListaNepokretnosti", "brojParcele", "deoParceleId", "katastarskaOpstinaId", "klasa", "klasaStvarnoStanje", "korisnikParcele", "kultura", "kulturaStvarsnoStanje", "oblikSvojine", "obradivost", "obradivostStvarnoStanje", "odvodnjavanje", "odvodnjavanjeStvarnoStanje", "povrsina", "zasticenaZona", "zasticenaZonaStvarnoStanje" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, "vrhunska", "visoka", "Masa Bobar", "kultura1", "visoka", "Nasledstvo", "visoka", "niska", "da", "povoljno", "300m2", "ima", "visoka" },
                    { 2, 2, 2, 2, 2, "vrhunska", "visoka", "Uros Bobar", "kultura1", "visoka", "Nasledstvo", "visoka", "niska", "da", "povoljno", "400m2", "ima", "visoka" },
                    { 3, 3, 3, 3, 3, "vrhunska", "visoka", "Aleksa Bobar", "kultura1", "visoka", "Nasledstvo", "visoka", "niska", "da", "povoljno", "500m2", "ima", "visoka" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_parcela_deoParceleId",
                table: "parcela",
                column: "deoParceleId");

            migrationBuilder.CreateIndex(
                name: "IX_parcela_katastarskaOpstinaId",
                table: "parcela",
                column: "katastarskaOpstinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcela");

            migrationBuilder.DropTable(
                name: "deoParcele");

            migrationBuilder.DropTable(
                name: "katastarskaOpstinaVO");
        }
    }
}
