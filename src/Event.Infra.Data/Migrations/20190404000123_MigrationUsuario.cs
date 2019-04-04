using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class MigrationUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EV_USUARIO",
                columns: table => new
                {
                    UK_ID = table.Column<Guid>(nullable: false),
                    TXT_NOME = table.Column<string>(nullable: false),
                    TXT_CPF = table.Column<string>(nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(type: "datetime", nullable: false),
                    TXT_EMPRESA_INSTITUICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EV_USUARIO", x => x.UK_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EV_USUARIO");
        }
    }
}
