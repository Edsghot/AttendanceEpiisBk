using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceEpiisBk.Migrations
{
    public partial class later : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Event",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Event");
        }
    }
}
