using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class MigrationAlteracoesUsuarioEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TXT_EMAIL",
                table: "EV_USUARIO",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EV_USUARIO_EVENTO",
                columns: table => new
                {
                    UK_USUARIO = table.Column<Guid>(nullable: false),
                    UK_EVENTO = table.Column<Guid>(nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EV_USUARIO_EVENTO", x => new { x.UK_EVENTO, x.UK_USUARIO });
                    table.ForeignKey(
                        name: "FK_EV_USUARIO_EVENTO_EV_EVENTO_UK_USUARIO",
                        column: x => x.UK_USUARIO,
                        principalTable: "EV_EVENTO",
                        principalColumn: "UK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EV_USUARIO_EVENTO_EV_USUARIO_UK_USUARIO",
                        column: x => x.UK_USUARIO,
                        principalTable: "EV_USUARIO",
                        principalColumn: "UK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EV_USUARIO_EVENTO_UK_USUARIO",
                table: "EV_USUARIO_EVENTO",
                column: "UK_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EV_USUARIO_EVENTO");

            migrationBuilder.DropColumn(
                name: "TXT_EMAIL",
                table: "EV_USUARIO");
        }
    }
}
