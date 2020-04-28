using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCV.Data.Domain.Migrations
{
    public partial class ChangedIDtoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "WorkExperiences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Languages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Educations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ComputerTechnologies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Certificates",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkExperiences",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Languages",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Educations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ComputerTechnologies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Certificates",
                newName: "ID");
        }
    }
}
