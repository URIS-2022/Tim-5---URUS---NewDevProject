using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zalba_Mikroservis.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KupacID",
                table: "Zalbas",
                newName: "KupacVO");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbas_KupacVO",
                table: "Zalbas",
                column: "KupacVO");

            migrationBuilder.AddForeignKey(
                name: "FK_Zalbas_KupacVOs_KupacVO",
                table: "Zalbas",
                column: "KupacVO",
                principalTable: "KupacVOs",
                principalColumn: "KupacID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zalbas_KupacVOs_KupacVO",
                table: "Zalbas");

            migrationBuilder.DropIndex(
                name: "IX_Zalbas_KupacVO",
                table: "Zalbas");

            migrationBuilder.RenameColumn(
                name: "KupacVO",
                table: "Zalbas",
                newName: "KupacID");
        }
    }
}
