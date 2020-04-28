using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCV.Data.Domain.Migrations
{
    public partial class ChangeLanguageCodetoLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "Languages");

            migrationBuilder.AddColumn<string>(
                name: "LanguageText",
                table: "Languages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageText",
                table: "Languages");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
