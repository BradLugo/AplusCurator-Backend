using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplusCurator.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    EmergencyContactName = table.Column<string>(maxLength: 127, nullable: true),
                    EmergencyContactPhone = table.Column<string>(maxLength: 15, nullable: true),
                    EmploymentStartDate = table.Column<DateTime>(nullable: false),
                    EmploymentTerminationDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 127, nullable: false),
                    LastName = table.Column<string>(maxLength: 127, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 127, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
