using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class MigrationAdicionandoCategoriaEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EV_CATEGORIA",
                columns: table => new
                {
                    UK_ID = table.Column<Guid>(nullable: false),
                    TXT_NOME = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EV_CATEGORIA", x => x.UK_ID);
                });

            migrationBuilder.CreateTable(
                name: "EV_CATEGORIA_EVENTO",
                columns: table => new
                {
                    UK_CATEGORIA = table.Column<Guid>(nullable: false),
                    UK_EVENTO = table.Column<Guid>(nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EV_CATEGORIA_EVENTO", x => new { x.UK_EVENTO, x.UK_CATEGORIA });
                    table.ForeignKey(
                        name: "FK_EV_CATEGORIA_EVENTO_EV_CATEGORIA_UK_CATEGORIA",
                        column: x => x.UK_CATEGORIA,
                        principalTable: "EV_CATEGORIA",
                        principalColumn: "UK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EV_CATEGORIA_EVENTO_EV_EVENTO_UK_EVENTO",
                        column: x => x.UK_EVENTO,
                        principalTable: "EV_EVENTO",
                        principalColumn: "UK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EV_CATEGORIA_EVENTO_UK_CATEGORIA",
                table: "EV_CATEGORIA_EVENTO",
                column: "UK_CATEGORIA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EV_CATEGORIA_EVENTO");

            migrationBuilder.DropTable(
                name: "EV_CATEGORIA");
        }
    }
}
