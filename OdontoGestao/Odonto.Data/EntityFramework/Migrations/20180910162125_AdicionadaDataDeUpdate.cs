using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odonto.Data.EntityFramework.Migrations
{
    public partial class AdicionadaDataDeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraModificacao",
                table: "Topicos",
                nullable: false,
                defaultValue: DateTime.Now);
 
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraModificacao",
                table: "Licoes",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraModificacao",
                table: "Assuntos",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraModificacao",
                table: "Topicos");

            migrationBuilder.DropColumn(
                name: "DataHoraModificacao",
                table: "Licoes");

            migrationBuilder.DropColumn(
                name: "DataHoraModificacao",
                table: "Assuntos");
        }
    }
}
