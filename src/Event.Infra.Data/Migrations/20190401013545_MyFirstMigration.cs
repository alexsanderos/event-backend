using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.Infra.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EV_EVENTO",
                columns: table => new
                {
                    UK_ID = table.Column<Guid>(nullable: false),
                    TXT_TITULO = table.Column<string>(nullable: false),
                    TXT_SUBTITULO = table.Column<string>(nullable: false),
                    TXT_DESCRICAO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EV_EVENTO", x => x.UK_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EV_EVENTO");
        }
    }
}
