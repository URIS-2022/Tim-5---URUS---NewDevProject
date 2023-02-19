using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zalba_Mikroservis.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Zalbas_KupacID",
                table: "Zalbas",
                column: "KupacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zalbas_KupacVOs_KupacID",
                table: "Zalbas",
                column: "KupacID",
                principalTable: "KupacVOs",
                principalColumn: "KupacID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zalbas_KupacVOs_KupacID",
                table: "Zalbas");

            migrationBuilder.DropIndex(
                name: "IX_Zalbas_KupacID",
                table: "Zalbas");
        }
    }
}
