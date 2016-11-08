using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplusCurator.Migrations
{
    public partial class UpdatedAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExitTime",
                table: "InstructorsAttendance");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "InstructorsAttendance",
                type: "Time",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "InstructorsAttendance");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitTime",
                table: "InstructorsAttendance",
                type: "Time",
                nullable: true);
        }
    }
}
