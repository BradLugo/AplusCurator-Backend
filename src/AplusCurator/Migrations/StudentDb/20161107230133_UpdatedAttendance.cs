using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplusCurator.Migrations.StudentDb
{
    public partial class UpdatedAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExitTime",
                table: "StudentsAttendance");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "StudentsAttendance",
                type: "Time",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "StudentsAttendance");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitTime",
                table: "StudentsAttendance",
                type: "Time",
                nullable: true);
        }
    }
}
