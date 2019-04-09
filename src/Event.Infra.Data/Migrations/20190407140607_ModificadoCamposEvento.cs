using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class ModificadoCamposEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TXT_DESCRICAO",
                table: "EV_EVENTO",
                newName: "TXT_DESCRICAO_LONGA");

            migrationBuilder.AddColumn<string>(
                name: "TXT_DESCRICAO_CURTA",
                table: "EV_EVENTO",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TXT_DESCRICAO_CURTA",
                table: "EV_EVENTO");

            migrationBuilder.RenameColumn(
                name: "TXT_DESCRICAO_LONGA",
                table: "EV_EVENTO",
                newName: "TXT_DESCRICAO");
        }
    }
}
