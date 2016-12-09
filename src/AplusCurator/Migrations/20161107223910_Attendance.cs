using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplusCurator.Migrations
{
    public partial class Attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstructorsAttendance",
                columns: table => new
                {
                    InstructorAttendanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendanceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "Time", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "Time", nullable: true),
                    InstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorsAttendance", x => x.InstructorAttendanceId);
                });

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentTerminationDate",
                table: "Instructors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorsAttendance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentTerminationDate",
                table: "Instructors",
                nullable: false);
        }
    }
}
