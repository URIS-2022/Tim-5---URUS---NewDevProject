using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zalba_Mikroservis.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KupacVOs_KupacVOs_KupacVOKupacID",
                table: "KupacVOs");

            migrationBuilder.DropIndex(
                name: "IX_KupacVOs_KupacVOKupacID",
                table: "KupacVOs");

            migrationBuilder.DropColumn(
                name: "KupacVOKupacID",
                table: "KupacVOs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KupacVOKupacID",
                table: "KupacVOs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KupacVOs_KupacVOKupacID",
                table: "KupacVOs",
                column: "KupacVOKupacID");

            migrationBuilder.AddForeignKey(
                name: "FK_KupacVOs_KupacVOs_KupacVOKupacID",
                table: "KupacVOs",
                column: "KupacVOKupacID",
                principalTable: "KupacVOs",
                principalColumn: "KupacID");
        }
    }
}
