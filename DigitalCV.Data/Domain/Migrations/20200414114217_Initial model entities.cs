using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCV.Data.Domain.Migrations
{
    public partial class Initialmodelentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateName = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateName);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    NameOfEducation = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    TimePeriod = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.NameOfEducation);
                });

            migrationBuilder.CreateTable(
                name: "ITExperiences",
                columns: table => new
                {
                    ITGroup = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    ITSkills = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITExperiences", x => x.ITGroup);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    LevelOfLanguage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageCode);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Updated = table.Column<DateTime>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    TimePeriod = table.Column<string>(nullable: true),
                    NameOfCompany = table.Column<string>(nullable: true),
                    WorkingAs = table.Column<string>(nullable: true),
                    KeyAreas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "ITExperiences");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "WorkExperiences");
        }
    }
}
