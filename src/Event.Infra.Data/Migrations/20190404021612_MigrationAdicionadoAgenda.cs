using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class MigrationAdicionadoAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EV_AGENDA",
                columns: table => new
                {
                    UK_ID = table.Column<Guid>(nullable: false),
                    DT_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DT_FIM = table.Column<DateTime>(type: "datetime", nullable: false),
                    UK_ID_EVENTO = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EV_AGENDA", x => x.UK_ID);
                    table.ForeignKey(
                        name: "FK_EV_AGENDA_EV_EVENTO_UK_ID_EVENTO",
                        column: x => x.UK_ID_EVENTO,
                        principalTable: "EV_EVENTO",
                        principalColumn: "UK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EV_AGENDA_UK_ID_EVENTO",
                table: "EV_AGENDA",
                column: "UK_ID_EVENTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EV_AGENDA");
        }
    }
}
