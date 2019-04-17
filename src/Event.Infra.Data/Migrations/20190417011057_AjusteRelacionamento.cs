using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class AjusteRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EV_CATEGORIA_EVENTO");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCategoria",
                table: "EV_EVENTO",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "INT_VAGAS",
                table: "EV_EVENTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EV_EVENTO_IdCategoria",
                table: "EV_EVENTO",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_EV_EVENTO_EV_CATEGORIA_IdCategoria",
                table: "EV_EVENTO",
                column: "IdCategoria",
                principalTable: "EV_CATEGORIA",
                principalColumn: "UK_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EV_EVENTO_EV_CATEGORIA_IdCategoria",
                table: "EV_EVENTO");

            migrationBuilder.DropIndex(
                name: "IX_EV_EVENTO_IdCategoria",
                table: "EV_EVENTO");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "EV_EVENTO");

            migrationBuilder.DropColumn(
                name: "INT_VAGAS",
                table: "EV_EVENTO");

            migrationBuilder.CreateTable(
                name: "EV_CATEGORIA_EVENTO",
                columns: table => new
                {
                    UK_EVENTO = table.Column<Guid>(nullable: false),
                    UK_CATEGORIA = table.Column<Guid>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false)
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
    }
}
