using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Komisija_Sergej.Migrations
{
    /// <inheritdoc />
    public partial class InitiallCOmit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komisije",
                columns: table => new
                {
                    KomisijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Predsednik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisije", x => x.KomisijaID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komisije");
        }
    }
}
