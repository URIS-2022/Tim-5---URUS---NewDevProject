using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZasticenaZonaMikroservis.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZasticeneZone",
                columns: table => new
                {
                    ZasticenaZonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DozvoljeniRadovi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepenZastite = table.Column<int>(type: "int", nullable: false),
                    VrstaZasticenogPodrucja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZasticeneZone", x => x.ZasticenaZonaID);
                });

            migrationBuilder.InsertData(
                table: "ZasticeneZone",
                columns: new[] { "ZasticenaZonaID", "DozvoljeniRadovi", "StepenZastite", "VrstaZasticenogPodrucja" },
                values: new object[] { 5, "uredjivanje staza", 5, "Nacionalni park" });

            migrationBuilder.InsertData(
                table: "ZasticeneZone",
                columns: new[] { "ZasticenaZonaID", "DozvoljeniRadovi", "StepenZastite", "VrstaZasticenogPodrucja" },
                values: new object[] { 13, "kopanje", 3, "rezervat" });

            migrationBuilder.InsertData(
                table: "ZasticeneZone",
                columns: new[] { "ZasticenaZonaID", "DozvoljeniRadovi", "StepenZastite", "VrstaZasticenogPodrucja" },
                values: new object[] { 15, "kopanje, asfaltiranje", 4, "arheolosko naselje" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZasticeneZone");
        }
    }
}
