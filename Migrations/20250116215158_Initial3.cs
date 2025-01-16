using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceEpiisBk.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Attendance",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLate",
                table: "Attendance",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "IsLate",
                table: "Attendance");
        }
    }
}
