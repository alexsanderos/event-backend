using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class ajusteIdUsuarioEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EV_USUARIO_EVENTO_EV_EVENTO_UK_USUARIO",
                table: "EV_USUARIO_EVENTO");

            migrationBuilder.AddForeignKey(
                name: "FK_EV_USUARIO_EVENTO_EV_EVENTO_UK_EVENTO",
                table: "EV_USUARIO_EVENTO",
                column: "UK_EVENTO",
                principalTable: "EV_EVENTO",
                principalColumn: "UK_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EV_USUARIO_EVENTO_EV_EVENTO_UK_EVENTO",
                table: "EV_USUARIO_EVENTO");

            migrationBuilder.AddForeignKey(
                name: "FK_EV_USUARIO_EVENTO_EV_EVENTO_UK_USUARIO",
                table: "EV_USUARIO_EVENTO",
                column: "UK_USUARIO",
                principalTable: "EV_EVENTO",
                principalColumn: "UK_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
