using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KorisnikSistema.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KorisniciSistemas",
                columns: table => new
                {
                    KorisnikSistemaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciSistemas", x => x.KorisnikSistemaID);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnikas",
                columns: table => new
                {
                    TipKorisnikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisniciSistemaKorisnikSistemaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKorisnikas", x => x.TipKorisnikaID);
                    table.ForeignKey(
                        name: "FK_TipKorisnikas_KorisniciSistemas_KorisniciSistemaKorisnikSistemaID",
                        column: x => x.KorisniciSistemaKorisnikSistemaID,
                        principalTable: "KorisniciSistemas",
                        principalColumn: "KorisnikSistemaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipKorisnikas_KorisniciSistemaKorisnikSistemaID",
                table: "TipKorisnikas",
                column: "KorisniciSistemaKorisnikSistemaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipKorisnikas");

            migrationBuilder.DropTable(
                name: "KorisniciSistemas");
        }
    }
}
