using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplusCurator.Migrations.GuardianDb
{
    public partial class newModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    GuardianId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 127, nullable: false),
                    ContactName = table.Column<string>(maxLength: 127, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 127, nullable: false),
                    Description = table.Column<string>(maxLength: 99999, nullable: true),
                    Email = table.Column<string>(maxLength: 127, nullable: false),
                    FirstName = table.Column<string>(maxLength: 127, nullable: false),
                    LastName = table.Column<string>(maxLength: 127, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 127, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 127, nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 99999, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.GuardianId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guardians");
        }
    }
}
