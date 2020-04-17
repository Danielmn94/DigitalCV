using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCV.Data.Domain.Migrations
{
    public partial class RenamedITExperiencetoComputerTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITExperiences");

            migrationBuilder.CreateTable(
                name: "ComputerTechnologies",
                columns: table => new
                {
                    ITGroup = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Added = table.Column<DateTime>(nullable: false),
                    ITSkills = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerTechnologies", x => x.ITGroup);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerTechnologies");

            migrationBuilder.CreateTable(
                name: "ITExperiences",
                columns: table => new
                {
                    ITGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ITSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITExperiences", x => x.ITGroup);
                });
        }
    }
}
