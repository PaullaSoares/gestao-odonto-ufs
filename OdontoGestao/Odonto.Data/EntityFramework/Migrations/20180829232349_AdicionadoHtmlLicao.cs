using Microsoft.EntityFrameworkCore.Migrations;

namespace Odonto.Data.EntityFramework.Migrations
{
    public partial class AdicionadoHtmlLicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlLicao",
                table: "Licoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlLicao",
                table: "Licoes");
        }
    }
}
