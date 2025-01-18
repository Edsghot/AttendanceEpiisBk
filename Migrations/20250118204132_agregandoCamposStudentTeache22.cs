using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceEpiisBk.Migrations
{
    public partial class agregandoCamposStudentTeache22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExit",
                table: "Attendance",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExit",
                table: "Attendance");
        }
    }
}
