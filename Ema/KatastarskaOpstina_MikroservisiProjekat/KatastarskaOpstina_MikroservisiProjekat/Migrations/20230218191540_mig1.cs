using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KatastarskaOpstina_MikroservisiProjekat.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "katastarskaOpstina",
                columns: table => new
                {
                    katastarskaOpstinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    katastarskaOpstinaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_katastarskaOpstina", x => x.katastarskaOpstinaId);
                });

            migrationBuilder.CreateTable(
                name: "statutOpstine",
                columns: table => new
                {
                    statutOpstineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stav = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tacka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    katastarskaOpstinaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statutOpstine", x => x.statutOpstineID);
                    table.ForeignKey(
                        name: "FK_statutOpstine_katastarskaOpstina_katastarskaOpstinaID",
                        column: x => x.katastarskaOpstinaID,
                        principalTable: "katastarskaOpstina",
                        principalColumn: "katastarskaOpstinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "katastarskaOpstina",
                columns: new[] { "katastarskaOpstinaId", "katastarskaOpstinaNaziv" },
                values: new object[,]
                {
                    { 1, "Lipovac" },
                    { 2, "Brus" },
                    { 3, "Odzaci" }
                });

            migrationBuilder.InsertData(
                table: "statutOpstine",
                columns: new[] { "statutOpstineID", "clan", "katastarskaOpstinaID", "stav", "tacka" },
                values: new object[,]
                {
                    { 4, "prvi", 1, "11", "1" },
                    { 5, "drugi", 2, "12", "2" },
                    { 6, "treci", 3, "13", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_statutOpstine_katastarskaOpstinaID",
                table: "statutOpstine",
                column: "katastarskaOpstinaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statutOpstine");

            migrationBuilder.DropTable(
                name: "katastarskaOpstina");
        }
    }
}
