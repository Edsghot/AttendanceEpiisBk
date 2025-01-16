using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceEpiisBk.Migrations
{
    public partial class agregandoCamposStudentTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Teacher",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Student",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Student",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Student");
        }
    }
}
