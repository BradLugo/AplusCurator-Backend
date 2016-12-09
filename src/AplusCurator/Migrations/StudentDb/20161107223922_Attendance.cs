using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplusCurator.Migrations.StudentDb
{
    public partial class Attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsAttendance",
                columns: table => new
                {
                    StudentAttendanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendanceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "Time", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "Time", nullable: true),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsAttendance", x => x.StudentAttendanceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsAttendance");
        }
    }
}
